namespace ParkingLot.One;

public class Car : Vehicle
{
    public override int RequiredSpots => 1;
    public override VehicleType Type => VehicleType.Car;
}
