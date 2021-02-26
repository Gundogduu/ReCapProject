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
    public class EfUserDal : EfEntityRepositoryBase<User, DatabasecampContext>, IUserDal
    {
        public List<UserDetailDto> GetUserDetails()
        {
            using (DatabasecampContext context = new DatabasecampContext())
            {
                var result = from u in context.Users
                             join c in context.Customers
                             on u.UserId equals c.UserId
                             select new UserDetailDto
                             {
                                 UserId = u.UserId, CompanyName = c.CompanyName,
                                 CustomerId = c.CustomerId
                             };
                return result.ToList();

            }
        }
    }
}
