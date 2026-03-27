using cw2APBD.Domain.Users;
using cw2APBD.Repos.Interfaces;
using cw2APBD.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw2APBD.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRentalRepository _rentalRepository;

        public UserService(IUserRepository userRepository, IRentalRepository rentalRepository)
        {
            _userRepository = userRepository;
            _rentalRepository = rentalRepository;
        }

        public void AddUser(User user)
        {
            _userRepository.Add(user);
        }

        public User? GetUserById(string id)
        {
            return _userRepository.GetById(id);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public bool CanRentMore(User user)
        {
            if (user == null) return false;

            int activeRentals = _rentalRepository.GetByUser(user)
                .Count(r => !r.IsReturned);

            return activeRentals < user.GetMaxRentals();
        }
    }
}
