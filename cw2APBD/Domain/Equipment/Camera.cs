namespace cw2APBD.Domain.Equipment;

public class Camera : Equipment
{
    public string PhotoSensor {  get; private set; }
    public double MaxZoom { get; private set; }

    public Camera(string name, int cost, string photoSensor, double maxZoom) : base(name, cost)
    {
        PhotoSensor = photoSensor;
        MaxZoom = maxZoom;
    }

    public override string GetInfo()
    {
        return $"Sensor: {PhotoSensor} MaxZoom: {MaxZoom}";
    }

}