using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Business.Utilities.BusinessRules;
using Core.Utilities.Helpers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.ComplexTypes;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            ShowDefaultImage(result, carId);
            return new SuccessDataResult<List<CarImage>>(result);
        }
        private IResult ShowDefaultImage(List<CarImage> result, int carId)
        {
            if (!result.Any())
            {
                var defaultCarImage = new CarImage
                {
                    CarId = carId,
                    Date = DateTime.Now,
                    ImagePath = Environment.CurrentDirectory + @"\uploads\DefaultCar.jpg"
                };
                result.Add(defaultCarImage);
            }

            return new SuccessResult();
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRulesHelper.Check(CheckIfCarImageLimitExceeded(carImage.CarId));
            if (!result.Success)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.AddCarImage);
        }

        private IResult CheckIfCarImageLimitExceeded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count == 5)
            {
                return new ErrorResult(Messages.CarImageLimit);
            }

            return new SuccessResult();
        }


        public IResult Update(IFormFile file, CarImage carImage)
        {
            var oldPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\\..\\..\\wwwroot")) +
                          _carImageDal.Get(c => c.Id == carImage.Id).ImagePath;

            carImage.ImagePath = FileHelper.Update(oldPath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.UpdateCarImage);
        }

        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.DeleteCarImage);
        }

        public IDataResult<List<CarImageDetails>> GetCarImageDetails()
        {
            return new SuccessDataResult<List<CarImageDetails>>(_carImageDal.GetCarImageDetails());
        }
    }
}
