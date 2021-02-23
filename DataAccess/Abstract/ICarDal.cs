using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        //burada artık Car'a özel operasyonları yazabiliriz dto gibi.
        List<CarDetailDto> GetCarDetails();
    }
}
