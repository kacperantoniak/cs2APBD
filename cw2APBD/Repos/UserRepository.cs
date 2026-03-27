using cw2APBD.Domain.Users;
using cw2APBD.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw2APBD.Repos
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
    }
}
