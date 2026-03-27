namespace cw2APBD.Domain.Equipment;

public class Projector : Equipment
{
    public int Lumens {  get; private set; }
    public string Resolution { get; private set; }

    public Projector(string name, int cost, int lumens, string resolution) : base(name, cost)
    {
        Lumens = lumens;
        Resolution = resolution;
    }

    public override string GetInfo()
    {
        return $"Lumens: {Lumens} Resolution: {Resolution}";
    }
}