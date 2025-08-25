namespace ParkingLot.One;

public abstract class Vehicle
{
    public required string LicensePlate { get; set; }
    public DateTime EntryTime { get; set; }
    public abstract int RequiredSpots { get; }
    public abstract VehicleType Type { get; }
}

public class CarWith3Spots : Vehicle
{
    public override int RequiredSpots => 3;
    public override VehicleType Type => VehicleType.Car;
}