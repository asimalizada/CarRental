﻿using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.ComplexTypes;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = CheckIfCarReturned(rental.CarId);
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.AddRental);
        }
        private IResult CheckIfCarReturned(int carId)
        {
            var result = _rentalDal.GetCarRentalDetails(r => r.CarId == carId & r.ReturnDate != null);
            if (result.Count > 0)
            {
                return new ErrorResult(Messages.CarDidNotReturned);
            }

            return new SuccessResult(Messages.CarRented);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.UpdateRental);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.DeleteRental);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        public IDataResult<List<CarRentalDetails>> GetCarRentalDetails()
        {
            return new SuccessDataResult<List<CarRentalDetails>>(_rentalDal.GetCarRentalDetails());
        }

        public IDataResult<List<RentalDetails>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetails>>(_rentalDal.GetRentalDetails());
        }

        private bool CheckIfCarReturned(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId).FindLast(r=>r.CarId == rental.CarId);
            if (result.ReturnDate != null)
            {
                return true;
            }

            return false;
        }
    }
}
