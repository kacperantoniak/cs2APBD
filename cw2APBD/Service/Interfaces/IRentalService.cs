using cw2APBD.Domain;
using cw2APBD.Domain.Equipment;
using cw2APBD.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw2APBD.Service.Interfaces
{
    public interface IRentalService
    {
        Rental RentEquipment(User user, Equipment equipment, int rentalDays);
        Rental ReturnEquipment(string rentalId);
        List<Rental> GetActiveRentalsByUser(User user);
        List<Rental> GetOverdueRentals();
        List<Rental> GetAllRentals();
        double CalculateFee(Rental rental);
    }
}
