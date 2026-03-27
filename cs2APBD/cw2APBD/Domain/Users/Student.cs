namespace cw2APBD.Domain.Users;

public class Student : User
{
    public string StudentId { get; private set; }
    public string StudyType { get; private set; }
    public string Studies { get; private set; }

    public Student(string name, string lname, string email, string studyType, string studies) : base(name, lname, email)
    {
        StudentId = $"s{base.Id}";
        StudyType = studyType;
        Studies = studies;
    }

    public override int GetMaxRentals()
    {
        return 2;
    }
}