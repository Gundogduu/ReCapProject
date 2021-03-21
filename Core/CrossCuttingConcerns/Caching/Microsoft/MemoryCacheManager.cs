using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;
using System.Linq;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    //Adapter Pattern'ı uyguluyoruz.Yani var olan bir sistemi kendi sistemime uyarlıyorum.
    //Microsoft'un kendi cache kütüphanesini kullanacağız burada
    //aşağıdaki .Net'in MemoryCache kodlarını kendi sistemime uyarlıyorum.
    public class MemoryCacheManager : ICacheManager
    {
        IMemoryCache _memoryCache;

        //CoreModule'de intance'ını oluşturduk burada da çağırıyoruz. using'ini getirmedi elle girdik.
        public MemoryCacheManager()
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }

        public void Add(string key, object value, int duration)
        {
            //cache de kalacak kod anlamına geliyor
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        //böyle bir cache değeri var mı?
        //tryValue, istersen verdiğin key'in değerini de sana out ile geri döndürebilirim diyor.
        //Buna ihtiyacımız olmadığından out'a altçizgi veriyoruz. C# da o değeri bana verme demenin karşılığı bu.
        public bool IsAdd(string key)
        {
            return _memoryCache.TryGetValue(key, out _);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        //RemoveByPattern, çalışma anında bellekten silmeye yarıyor.Reflection'ı işlemiştik. Elinizde bir sınıfın instance'ı var ve çalışma anında ona müdehale etmek istiyorsunuz bunu reflectio^n ile yapıyoruz.
        //Reflection ile çalışma anında nesne oluşturma ve müdehale etme gibi çalışmalar yapabiliriz.
        //var Ona verdiğimiz pattern ile silme işlemini yapacak.Mesela [CacheRemoveAspect("ICarService.Get")] pattern'ı gibi.
        //MemoryCache verisini bellekte EntriesCollection diye bir yerde tutuyor. Bunları ezbere bilemezsiniz .Net dökümanında MemoryCache ile ilgili herşeyi bulabilirsiniz.
        public void RemoveByPattern(string pattern)
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }
            //yukarıda her bir cache elemanını gez diyoruz ve burada regex değerini yani verdiğimiz pattern'ı şu şekilde oluştur
            //yani SingleLine olacak,Compiled olacak ekstradan ben conpiled etmeyeceğim ve CaseSensivity olmayacak ve bu noktada o cache datası içinde anahtarlardan benim gönderdiğim şu kuralllara uyanları gez,
            //key'lerini bul ve onları remove et diyerek bellekten uçur diyoruz.Bunları ezbere bilemezsiniz bana bunları tekrar yaz deseniz hatırlamam nasıl tuttuğunu filan.
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            foreach (var key in keysToRemove)
            {
                _memoryCache.Remove(key);
            }
        }
    }
}
//IMemoryCache bir interface dolayısıyla onu çözmem lazım.Constructor ile enjecte etsek çalışmaz, çünkü zincirin dışında, zincir:WebAPI>Business>DataAccess.
//Aspect bambaşka bir şey, dolayısıyla bunun için bir ServiceTool yaptık.ServiceTool'umuzuda ICoreModule'a enjecte etmiştik.
//Dolayısıyla ICacheManager'ın da yine oraya instance'ını veriyoruz.
//Yine serviceCollection.AddMemoryCache(); diyerek de IMemoryCache injection'ınında karşılığını oluşturduk.