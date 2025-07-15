using CheckNationalCode.Core.ApplicationServices.Users;
using InfraStructures.Data.EF.SqlServer.Common;

namespace InfraStructures.Data.EF.SqlServer.RequestUser
{
    public class RequestUserRepository : BaseRepository<CheckNationalCode.Core.Domain.Users.RequestUser>, IRequestUserRepository
    {
        public RequestUserRepository(RequestUserContext dbContext) : base(dbContext)
        {


        }
    }
}
