using cw2APBD.Domain;
using cw2APBD.Domain.Equipment;
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
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IEquipmentService _equipmentService;
        private readonly IUserService _userService;

        public RentalService(IRentalRepository rentalRepository, IEquipmentService equipmentService, IUserService userService)
        {
            _rentalRepository = rentalRepository;
            _equipmentService = equipmentService;
            _userService = userService;
        }

        public Rental RentEquipment(User user, Equipment equipment, int rentalDays)
        {
            if (user == null)
                throw new InvalidOperationException("User not found");

            if (equipment == null)
                throw new InvalidOperationException("Equipment not found");

            if (!_equipmentService.IsEquipmentAvailable(equipment))
                throw new InvalidOperationException("Equipment is not available for rental");

            if (!_userService.CanRentMore(user))
                throw new InvalidOperationException($"User has reached maximum rental limit of {user.GetMaxRentals()} items");

            Rental rental = new(user, equipment, rentalDays);

            _equipmentService.UpdateEquipmentStatus(equipment, EquipmentStatus.Rented);

            _rentalRepository.Add(rental);

            return rental;
        }

        public Rental ReturnEquipment(string rentalId)
        {
            Rental? rental = _rentalRepository.GetById(rentalId);
            if (rental == null)
                throw new InvalidOperationException("Rental not found");

            if (rental.IsReturned)
                throw new InvalidOperationException("Equipment already returned");

            rental.ReturnDate = DateTime.Now;
            rental.IsReturned = true;

            if (rental.IsOverdue())
            {
                rental.Fee = CalculateFee(rental);
            }

            _equipmentService.UpdateEquipmentStatus(rental.RentedEquipment, EquipmentStatus.Available);
            _rentalRepository.Update(rental);

            return rental;
        }

        public List<Rental> GetActiveRentalsByUser(User user)
        {
            if (user == null) return new List<Rental>();

            return _rentalRepository.GetByUser(user)
                .Where(r => !r.IsReturned)
                .ToList();
        }

        public List<Rental> GetOverdueRentals()
        {
            return _rentalRepository.GetOverdueRentals();
        }

        public List<Rental> GetAllRentals()
        {
            return _rentalRepository.GetAll();
        }

        public double CalculateFee(Rental rental)
        {
            if (!rental.IsOverdue() || rental.ReturnDate == null)
                return 0;

            int daysOverdue = (rental.ReturnDate.Value - rental.ExpectedReturnDate).Days;
            if (daysOverdue <= 0) return 0;

            double itemFee = rental.RentedEquipment.Cost * 0.1;

            return daysOverdue * itemFee;
        }
    }
}
