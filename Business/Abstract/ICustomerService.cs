﻿using System.Collections.Generic;
using Core.Utilities.Results.Abstract;
using Entities.ComplexTypes;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetById(int id);
        IDataResult<List<CustomerDetails>> GetCustomerDetails();
    }
}
