using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id= 1, BrandId = "Honda", ColorId= "White",DailyPrice=125,ModelYear="2015",Description="Bluemotion Firmanın Ofisi " +
                "Aracınızı, Bluemotion firmasının ofisinden teslim alacaksınız."};
            new Car
            {
                Id = 2,
                BrandId = "Honda",
                ColorId = "Black",
                DailyPrice = 125,
                ModelYear = "2015",
                Description = "Bluemotion Firmanın Ofisi " +
            "Aracınızı, Bluemotion firmasının ofisinden teslim alacaksınız."
            };
            new Car
            {
                Id = 3,
                BrandId = "Honda",
                ColorId = "White",
                DailyPrice = 125,
                ModelYear = "2015",
                Description = "Bluemotion Firmanın Ofisi " +
            "Aracınızı, Bluemotion firmasının ofisinden teslim alacaksınız."
            };
            new Car
            {
                Id = 4,
                BrandId = "Honda",
                ColorId = "White",
                DailyPrice = 125,
                ModelYear = "2015",
                Description = "Bluemotion Firmanın Ofisi " +
            "Aracınızı, Bluemotion firmasının ofisinden teslim alacaksınız."
            };
            new Car
            {
                Id = 5,
                BrandId = "Honda",
                ColorId = "White",
                DailyPrice = 125,
                ModelYear = "2015",
                Description = "Bluemotion Firmanın Ofisi " +
            "Aracınızı, Bluemotion firmasının ofisinden teslim alacaksınız."
            };
        };
        }

        public void Add(Car car)
        {
            
        }

        public void Delete(Car car)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
