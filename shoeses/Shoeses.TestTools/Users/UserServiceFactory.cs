using Shoeses.persistence.EF.Users;
using Shoeses.persistence.EF;
using Shoeses.Services.Users.Contracts;
using Shoeses.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.persistence.EF.Addresses;
using Shoeses.Services.Addresses.Contracts;

namespace Shoeses.TestTools.Users
{
    public static class UserServiceFactory
    {
        public static UserService Create(EFDataContext context)
        {
            return new UserAppService(new EFUnitOfWork(context), new EFUserRepository(context),new EFAdressRepository(context));
        }
    }
}
