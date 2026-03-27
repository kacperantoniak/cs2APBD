using cw2APBD.Domain;
using cw2APBD.Domain.Users;
using cw2APBD.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw2APBD.Repos
{
    public class RentalRepository : GenericRepository<Rental>, IRentalRepository
    {
        public List<Rental> GetActiveRentals()
        {
            return _storage.Where(r => !r.IsReturned).ToList();
        }

        public List<Rental> GetOverdueRentals()
        {
            return _storage.Where(r => r.IsOverdue()).ToList();
        }

        public List<Rental> GetByUser(User user)
        {
            return _storage.Where(r => r.User.Id == user.Id).ToList();
        }
    }
}
