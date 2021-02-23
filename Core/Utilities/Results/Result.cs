using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //Bu, Constructor'ın kendi içindeki yapılarla çalışmasına bir örnek
        
        //c# ta this demek bu class denektir
        //:this(success) bu class'ın tek parametreli constructor'ına success'i yolla
        //şimdi kullanıcı iki parametre gönderirse ikinci constructor'da çalışacak.
        public Result(bool success, string message):this(success)
        {
            Message = message;
        }

        //method overloading kullandık çünkü mesaj vermek istemeyebiliriz
        public Result(bool success)
        {
            Success = success;
        }

        //işlem başarılı,başarısız
        public bool Success { get; }
        //bilgilendirme
        public string Message { get; }
    }
}
//property'lere set eylemi eklemedik ama getter'lar readonly'dir constructor da set'edilebilir!
//biz kullanıcının sadece constructor da set etmesini istediğimizden böyle sınırladık.