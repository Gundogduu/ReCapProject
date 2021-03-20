using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //ColorTest();
            //UserTest();
            //CustomerTest();
            RentalTest();
        }

        private static void RentalTest()
        {
            RentalManager manager = new RentalManager(new EfRentalDal());
            //var result = manager.Add(new Rental { CarId = 9, CustomerId = 3, RentDate = DateTime.Now});          //diğer kullanım: new DateTime(27.02.2021)
            //if (result.Success)
            //{
            //    Console.WriteLine(result.Message);
            //}

            foreach (var rent in manager.GetAll().Data)
            {
                Console.WriteLine("Customer ID: {0} Car ID: {1} Rent date: {2} Return date: {3}", rent.CustomerId, rent.CarId, rent.RentDate, rent.ReturnDate);
            }

        }

        private static void CustomerTest()
        {
            CustomerManager manager = new CustomerManager(new EfCustomerDal());
            var result = manager.Add(new Customer { UserId = 5 });
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void UserTest()
        {
            UserManager manager = new UserManager(new EfUserDal());
            var result = manager.Add(new User { FirstName = "Cemre", LastName = "Bol", Email = "bol23@outlook.com", PassWord = "23000" });
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ColorTest()
        {
            ColorManager manager = new ColorManager(new EfColorDal());
            foreach (var color in manager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }

            Console.WriteLine(manager.GetById(2).Message);
        }

        private static void BrandTest()
        {
            BrandManager manager = new BrandManager(new EfBrandDal());
            foreach (var brand in manager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }

            Console.WriteLine(manager.GetById(2).Message);
        }

        private static void CarTest()
        {
            CarManager manager = new CarManager(new EfCarDal(),
                new BrandManager(new EfBrandDal()));

            //ADD
            var result = manager.Add(new Car { BrandId = 5, ColorId = 1, DailyPrice = 145, ModelYear = "2014", Description = "Bluemotion firmasının ofisinden teslim alabilirsiniz" });
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
