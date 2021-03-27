using System.Collections.Generic;
using Core.DataAccess.Abstract;
using Entities.ComplexTypes;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICarImageDal : IEntityRepository<CarImage>
    {
        List<CarImageDetails> GetCarImageDetails();
    }
}
