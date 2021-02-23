using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
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

            using (DatabasecampContext context = new DatabasecampContext())
            {
                //iş kodları
                if (car.DailyPrice > 0 && context.Brands.First(b=>b.BrandId== car.BrandId).BrandName.Length > 2)
                {
                    _carDal.Add(car);
                    Console.WriteLine("Saved to db: Id Number " + car.CarId);
                }
                else
                {
                    Console.WriteLine("Data could not be saved. BrandName must not be less than 2 characters and DailyPrice must be greater than 0");
                }

            }
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

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
