using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, DatabasecampContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (DatabasecampContext context = new DatabasecampContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join cs in context.Customers
                             on r.CustomerId equals cs.CustomerId
                             select new RentalDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandId = c.BrandId,
                                 ColorId = c.ColorId,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 RentalId = r.RentalId,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 CustomerId = cs.CustomerId,
                                 UserId = cs.UserId,
                                 CompanyName = cs.CompanyName
                             };
                return result.ToList();
            }
            
        }
    }
}
