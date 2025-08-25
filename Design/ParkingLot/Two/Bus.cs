using ParkingLot.One;

namespace ParkingLot.Two;

public class Bus : Vehicle
{
    public Bus(String licensePlate): base(licensePlate, VehicleSize.Large)
    {
}

//public bool canFitInSpot(ParkingSpot spot)
//{
    
//}

    public override bool canFitInSpot(ParkingSpot spot)
    {
        return spot.getSpotSize() == VehicleSize.Large;
    }
}
