using CheckNationalCode.Core.ApplicationServices.Common;
using CheckNationalCode.Core.ApplicationServices.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taskSession2.InfraStructures.Data.EF.SqlServer.Common;

namespace InfraStructures.Data.EF.SqlServer.RequestUser
{
    public class RequestUserRepository : BaseRepository<CheckNationalCode.Core.Domain.Users.RequestUser>, IRequestUserRepository
    {
        public RequestUserRepository(RequestUserContext dbContext) : base(dbContext)
        {

        }
    }
}
