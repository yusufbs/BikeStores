namespace ParkingLot.One;

public class Bus : Vehicle
{
    public override int RequiredSpots => 5; // Assuming a bus requires 5 large spots
    public override VehicleType Type => VehicleType.Bus;
}