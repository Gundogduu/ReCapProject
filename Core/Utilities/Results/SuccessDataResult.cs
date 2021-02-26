using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data,string message) : base(data, true, message)
        {

        }
        
        public SuccessDataResult(T data) : base(data, true)                                 //mesajsız,sadece data döndürmek için
        {

        }

        public SuccessDataResult(string message) : base(default,true,message)               //default, olarak döndürmek. Çok az kullanacağımız bir yöntem ama bütün kullanımı görün diye yazdım
        {

        }

        public SuccessDataResult() : base(default,true)                                     //bu versiyonda da hiç bir şey vermiyorum sadece true döndür diyorum
        {

        }
    }
}
//bu son iki versiyonu çok kullanmayız ama bir altyapı oluşturduğumuzdan bütün alternatifleride kullandırma eğilimi olmalı.
