using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            this._carDal = carDal;
        }

        public void Add(Car car)
        {
            //iş kodları
            _carDal.Add(car);
            Console.WriteLine("Saved to db: Id Number " + car.CarId);
        }

        public List<Car> GetAll()
        {
           return _carDal.GetAll();
        }

        public List<Car> GetByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);

        }

        public List<Car> GetByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }
    }
}
