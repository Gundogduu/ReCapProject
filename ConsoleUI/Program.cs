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
            CarManager manager = new CarManager(new EfCarDal());

            //add
            manager.Add(new Car { BrandId = 6, ColorId = 1, DailyPrice = 145, ModelYear = "2014", Description = "Bluemotion firmasının ofisinden teslim alacaksınız" });

            //get
            foreach (var car in manager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            


        }
    }
}
