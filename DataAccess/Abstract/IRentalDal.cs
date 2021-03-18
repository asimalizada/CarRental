using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess.Abstract;
using Entities.ComplexTypes;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        List<CarRentalDetails> GetCarRentalDetails(Expression<Func<Rental, bool>> filter);
    }
}
