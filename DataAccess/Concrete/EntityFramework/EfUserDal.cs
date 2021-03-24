using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

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
                             on u.Id equals c.UserId
                             select new UserDetailDto
                             {
                                 UserId = u.Id, CompanyName = c.CompanyName,
                                 CustomerId = c.Id
                             };
                return result.ToList();

            }
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new DatabasecampContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }
    }
}
