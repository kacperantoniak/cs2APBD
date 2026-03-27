using Eq = cw2APBD.Domain.Equipment;
using cw2APBD.Domain.Users;

namespace cw2APBD.Domain;

public class Rental : IEntity
{
    public string Id { get; private set; }
    public User User { get; set; }
    public Eq.Equipment RentedEquipment { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime ExpectedReturnDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public double Fee { get; set; }
    public bool IsReturned { get; set; }

    public Rental(User user, Eq.Equipment rented, int rentedForDays)
    {
        Id = GenerateId();
        User = user;
        RentedEquipment = rented;
        RentalDate = DateTime.Now;
        ExpectedReturnDate = DateTime.Now.AddDays(rentedForDays);
        IsReturned = false;
        Fee = 0;
    }

    private string GenerateId()
    {
        return Guid.NewGuid().ToString().ToUpper();
    }

    public bool IsOverdue()
    {
        if(DateTime.Now >  ExpectedReturnDate)
            return true;
        else
            return false;
    }

    public int DaysOverdue()
    {
        return IsOverdue() ? (DateTime.Now - ExpectedReturnDate).Days : 0;
    }

}