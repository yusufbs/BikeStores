using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ParkingLot.Two;

public class Motorcycle : Vehicle
{
    public Motorcycle(string licensePlate) : base(licensePlate, VehicleSize.Motorcycle)
    {
}

public override bool    canFitInSpot(ParkingSpot spot)
{
    return true; // Can park in any spot
}
}
