using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                new Car
                {
                    CarId = 1, BrandId = 2, ColorId = 1, DailyPrice = 125, ModelYear = "2015",
                    Description = "Ford PUMA aracınızı, Bluemotion firmasının ofisinden teslim alacaksınız"},
                new Car
                {
                    CarId = 2, BrandId= 2,ColorId = 6, DailyPrice = 125, ModelYear = "2015",
                    Description = "Ford Fiesta aracınızı, Bluemotion firmasının ofisinden teslim alacaksınız."
                },
                new Car
                {
                    CarId = 3, BrandId = 3, ColorId = 3, DailyPrice = 125, ModelYear = "2015",
                    Description = "Volkswagen Polo aracınızı, Bluemotion firmasının ofisinden teslim alacaksınız."
                },
                new Car
                {
                    CarId = 4, BrandId = 8, ColorId = 7, DailyPrice = 125, ModelYear = "2015",
                    Description = "Renault Megane aracınızı, Bluemotion firmasının ofisinden teslim alacaksınız."
                },
                new Car
                {
                    CarId = 5, BrandId = 5, ColorId = 4, DailyPrice = 125, ModelYear = "2015",
                    Description = "Honda Civic aracınızı, Bluemotion firmasının ofisinden teslim alacaksınız."
                }
            };


        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int CarId)
        {
            return _cars.Where(c=>c.CarId == CarId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;

        }
    }
}
