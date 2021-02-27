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
        public static string CarUpdated = "Veri güncellendi";
        public static string CarDeleted = "Veri silindi";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarRented = "Araba kiralandı";
        public static string RentalsListed = "Kiralamalar listelendi";
        public static string RentalUpdated = "Kiralama güncellendi";
        public static string RentalCanceled = "Kiralama iptal edildi";
        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomersListed = "Müşteriler listelendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UsersListed = "Kullanıcılar listelendi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserDeleted = "Kullanıcı silindi";

    }
}

//static verdiğinizde istediğiniz yerde newlemeden direkt çağırabilirsiniz
//bu tip yapılarda böyle kullanırız

//Temel mesajlarımızı buranın içine koyacağız
//bunları değişken olmalarına rağmen pascalcase yazdık çünkü public olarak tanımladık. İçeride private field olarak tanımlasaydık carAdded,carInValid şeklinde yazardık.
//şu anda messagess sadece tool görevi görüyor. Daha ileri kullanımlarıda göreceğiz