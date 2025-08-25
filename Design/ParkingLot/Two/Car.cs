namespace ParkingLot.Two;

public class Car : Vehicle
{
    public Car(String licensePlate) : base(licensePlate, VehicleSize.Compact)
{
    
}

public override bool canFitInSpot(ParkingSpot spot)
{
    return spot.getSpotSize() == VehicleSize.Compact || spot.getSpotSize() == VehicleSize.Large;
}
}