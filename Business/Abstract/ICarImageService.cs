using System.Collections.Generic;
using Core.Utilities.Results.Abstract;
using Entities.ComplexTypes;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int id);
        IDataResult<List<CarImage>> GetByCarId(int carId);
        IResult Add(IFormFile file, CarImage carImage);
        IResult Update(IFormFile file, CarImage carImage);
        IResult Delete(CarImage carImage);
        IDataResult<List<CarImageDetails>> GetCarImageDetails();
    }
}
