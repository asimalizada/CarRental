using System.Collections.Generic;
using System.Linq;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.ComplexTypes;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarRentalDbContext>, ICustomerDal
    {
        public List<CustomerDetails> GetCustomerDetails()
        {
            using (CarRentalDbContext context = new CarRentalDbContext())
            {
                var result = from c in context.Customers
                    join u in context.Users on c.UserId equals u.Id
                    select new CustomerDetails
                    {
                        UserId = u.Id,
                        CustomerId = c.Id,
                        CompanyName = c.CompanyName,
                        UserFirstName = u.FirstName,
                        UserLastName = u.LastName
                    };
                return result.ToList();
            }
        }
    }
}
