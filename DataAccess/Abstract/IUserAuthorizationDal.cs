using System.Collections.Generic;
using Core.DataAccess.Abstract;
using Core.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserAuthorizationDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
