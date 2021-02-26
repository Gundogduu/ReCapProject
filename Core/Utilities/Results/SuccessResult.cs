using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        
        public SuccessResult(string message) : base(true, message)          //burada base demek yukarıdaki Result demek. Kullanıcının işleminin başarılı olduğunu bildiriyoruz.
        {

        }

        public SuccessResult() : base(true)                                 //method overloading, biz artık mesaj vermeden default olarak true döndürebiliriz
        {

        }
    }
}
//sektörde try-catch veya bu şekilde sadece true, mesaj döndüren veya false, message döndüren bir contructor yapısı kullanırız.