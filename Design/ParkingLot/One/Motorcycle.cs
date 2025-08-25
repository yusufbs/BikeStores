namespace ParkingLot.One;

public class Motorcycle : Vehicle
{
    public override int RequiredSpots => 1;
    public override VehicleType Type => VehicleType.Motorcycle;
}
