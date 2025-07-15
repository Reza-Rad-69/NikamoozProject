using CheckNationalCode.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckNationalCode.Core.ApplicationServices.Users
{
    public interface IRequestUserRepository
    {
        RequestUser Add(RequestUser entity);
    }
}
