﻿using System.Collections.Generic;
using Core.Utilities.Results.Abstract;
using Entities.ComplexTypes;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int id);
        IDataResult<List<CarRentalDetails>> GetCarRentalDetails();
        IDataResult<List<RentalDetails>> GetRentalDetails();
    }
}
