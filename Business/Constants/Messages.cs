using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarInValid = "Araba ismi geçersiz";
        public static string CarsListed = "Arabalar listelendi";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarDeleted = "Veri silindi";
        public static string CarUpdated = "Veri güncellendi";
    }
}

//static verdiğinizde istediğiniz yerde newlemeden direkt çağırabilirsiniz
//bu tip yapılarda böyle kullanırız

//Temel mesajlarımızı buranın içine koyacağız
//bunları değişken olmalarına rağmen pascalcase yazdık çünkü public olarak tanımladık. İçeride private field olarak tanımlasaydık carAdded,carInValid şeklinde yazardık.
//şu anda messagess sadece tool görevi görüyor. Daha ileri kullanımlarıda göreceğiz