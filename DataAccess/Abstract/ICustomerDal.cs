using System.Collections.Generic;
using Core.DataAccess.Abstract;
using Entities.ComplexTypes;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
        List<CustomerDetails> GetCustomerDetails();
    }
}
