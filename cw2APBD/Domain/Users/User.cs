namespace cw2APBD.Domain.Users;

public abstract class User : IEntity
{
    public string Id { get; private set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime Registered { get; private set; }

    protected User(string name, string lname, string email) 
    {
        Id = GenerateId();
        Name = name;
        LastName = lname;
        Email = email;
        Registered = DateTime.Now;
    }

    private string GenerateId()
    {
        return Guid.NewGuid().ToString().ToUpper();
    }

    public string GetUserType()
    {
        return GetType().Name;
    }

    public string GetFullName()
    {
        return $"{Name} {LastName}";
    }

    public abstract int GetMaxRentals();
}