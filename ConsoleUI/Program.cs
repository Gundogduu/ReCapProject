using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
            //BrandTest();
            //ColorTest();
           
        
        }

        private static void ColorTest()
        {
            ColorManager manager = new ColorManager(new EfColorDal());
            foreach (var color in manager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }

            Console.WriteLine(manager.GetById(2).ColorName);
        }

        private static void BrandTest()
        {
            BrandManager manager = new BrandManager(new EfBrandDal());
            foreach (var brand in manager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }

            Console.WriteLine(manager.GetById(2).BrandName);
        }

        private static void CarTest()
        {
            CarManager manager = new CarManager(new EfCarDal());

            //add
            //manager.Add(new Car { BrandId = 5, ColorId = 1, DailyPrice = 145, ModelYear = "2014", Description = "Bluemotion firmasının ofisinden teslim alabilirsiniz" });

            //get
            foreach (var car in manager.GetCarDetails())
            {
                Console.WriteLine("Brand: " + car.BrandName + " Color: " + car.ColorName + " Daily price: " + car.DailyPrice + " tl");
            }

            //update
            manager.Update(new Car { CarId = 30, BrandId = 2, ColorId = 3, DailyPrice = 125, ModelYear = "2016", Description = "Bluemotion firmasının ofisinden teslim alabilirsiniz"});

            //delete
            
           

        }
    }
}
