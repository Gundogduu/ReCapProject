using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        //ben sana bir key vereyim sen o key'e karşılık gelen datayı bana ver diyorum
        T Get<T>(string key);
        //generic olmayan versiyonu.Ama tip dönüşümünü yapmak gerekiyor.
        object Get(string key);
        void Add(string key, object value, int duration);
        //cache'de varmı diye kontrolünü yapabilmemizi sağlıyor
        bool IsAdd(string key);
        void Remove(string key);
        //mesela ismi get ile başlayanları uçur,key de category olanları uçur şeklinde bir pattern veriyoruz,ysni desen versem(yani,başı sonu önemli değil içinde get olanlar gibi).Dolayısıyla bizi baya bir koruyacak bir yöntem de bu olacak.
        void RemoveByPattern(string pattern);
    }
}
//value olarak herşeyi verebileceğimiz için object tipinde verdik.
//cache de ne kadar duracağını belirteceğimiz onun için de duration diye parametre ekliyorum.
//Bunu dakika veya saat cinsinden tutabiliriz.
//Bunun dışında cache'den bir data getirmek bu tek bir obje de olabilir(get) gibi, getAll() gibi çok objede içerebilir.
//Do0layısıyla burada farklı farklı veritipleri dönüşleri söz konusu,
//yani biz T döndüreceğiz bu T herşey olabilir.İsmi de Get olacak ama burada hangi tipte tuttuğumuzu get'in içinde belirtiyor olacağız.
//Şimdi bunun implementasyınunu yapacağız.
//başka bir cache'e geçmek istersek Core/Caching içine ekleyip kullanabiliriz.