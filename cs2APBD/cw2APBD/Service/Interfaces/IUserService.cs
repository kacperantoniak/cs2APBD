using cw2APBD.Domain;
using cw2APBD.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw2APBD.Service.Interfaces
{
    public interface IUserService
    {
        void AddUser(User user);
        User? GetUserById(string id);
        List<User> GetAllUsers();
        bool CanRentMore(User user);
    }
}
