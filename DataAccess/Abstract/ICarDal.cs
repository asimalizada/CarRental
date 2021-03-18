using System.Collections.Generic;
using Core.DataAccess.Abstract;
using Entities.ComplexTypes;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetails> GetCarDetails();
    }
}
