namespace cw2APBD.Domain.Equipment;

public class Laptop : Equipment
{
    public string Processor {  get; set; }
    public int RAMCapacity { get; set; }

    public Laptop(string name, int cost, string processor, int ram) : base(name, cost)
    {
        Processor = processor;
        RAMCapacity = ram;
    }

    public override string GetInfo()
    {
        return $"Processor: {Processor} RAM: {RAMCapacity}GB";
    }
}