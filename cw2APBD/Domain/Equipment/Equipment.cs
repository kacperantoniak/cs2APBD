namespace cw2APBD.Domain.Equipment;

public abstract class Equipment : IEntity
{
    public string Id { get; private set; }
    public string Name { get; set; }
    public int Cost { get; private set; }
    public EquipmentStatus Status { get; set; }
    public DateTime Created { get; private set; }

    protected Equipment(string name, int cost) 
    {
        Id = GenerateId();
        Name = name;
        Cost = cost;
        Status = EquipmentStatus.Available;
        Created = DateTime.Now;
    }

    private string GenerateId()
    {
        return Guid.NewGuid().ToString().ToUpper();
    }

    public string GetEquipmentType()
    {
        return GetType().Name;
    }

    public abstract string GetInfo();

    public override string ToString()
    {
        return $"UID: {Id} Type: {GetEquipmentType()} Name: {Name} Status: {Status}";
    }
}