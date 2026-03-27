namespace cw2APBD.Domain.Users;

public class Employee : User
{
    public string Department { get; set; }
    public int Salary { get; set; }
    public Employee? Manager { get; set; }

    public Employee(string name, string lname, string email, string department, int salary, Employee? manager) : base(name, lname, email)
    {
        Salary = salary;
        Department = department;
        Manager = manager;
    }

    public override int GetMaxRentals()
    {
        return 5;
    }
}