using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.ComplexTypes;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, CarRentalDbContext>, ICarImageDal
    {
        public List<CarImageDetails> GetCarImageDetails()
        {
            using (CarRentalDbContext context = new CarRentalDbContext())
            {
                var result = from c in context.Cars
                    join ci in context.CarImages on c.Id equals ci.CarId
                    join b in context.Brands on c.BrandId equals b.Id
                    join clr in context.Colors on c.ColorId equals clr.Id
                    select new CarImageDetails
                    {
                        Id = c.Id,
                        BrandName = b.Name,
                        CarName = c.CarName,
                        Description = c.Description,
                        DailyPrice = c.DailyPrice,
                        ImagePath = ci.ImagePath,
                        ModelYear = c.ModelYear,
                        ColorName = clr.Name
                    };

                return result.ToList();
            }
        }
    }
}
