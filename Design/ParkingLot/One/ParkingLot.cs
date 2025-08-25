namespace ParkingLot.One;

public class ParkingLot
{
    private List<ParkingSpot> spots;

    public ParkingLot(int numMotorcycleSpots, int numCompactSpots, int numLargeSpots)
    {
        spots = new List<ParkingSpot>();
        for (int i = 0; i < numMotorcycleSpots; i++)
            spots.Add(new ParkingSpot(i + 1, SpotType.Motorcycle));
        for (int i = 0; i < numCompactSpots; i++)
            spots.Add(new ParkingSpot(numMotorcycleSpots + i + 1, SpotType.Compact));
        for (int i = 0; i < numLargeSpots; i++)
            spots.Add(new ParkingSpot(numMotorcycleSpots + numCompactSpots + i + 1, SpotType.Large));
    }

    public bool ParkVehicle(Vehicle vehicle)
    {
        foreach (var spot in spots)
        {
            if (!spot.IsOccupied && CanVehicleFit(vehicle, spot))
            {
                spot.ParkVehicle(vehicle);
                Console.WriteLine($"Vehicle {vehicle.LicensePlate} parked in spot {spot.SpotNumber}.");
                return true;
            }
        }
        Console.WriteLine($"No suitable spot found for vehicle {vehicle.LicensePlate}.");
        return false;
    }

    public bool UnparkVehicle(string licensePlate)
    {
        foreach (var spot in spots)
        {
            if (spot.IsOccupied && spot.OccupiedByVehicle?.LicensePlate == licensePlate)
            {
                spot.RemoveVehicle();
                Console.WriteLine($"Vehicle {licensePlate} unparked from spot {spot.SpotNumber}.");
                // Implement fee calculation here
                return true;
            }
        }
        Console.WriteLine($"Vehicle {licensePlate} not found in parking lot.");
        return false;
    }

    private bool CanVehicleFit(Vehicle vehicle, ParkingSpot spot)
    {
        switch (vehicle.Type)
        {
            case VehicleType.Motorcycle:
                return true; // Motorcycles can park in any spot
            case VehicleType.Car:
                return spot.Type == SpotType.Compact || spot.Type == SpotType.Large;
            case VehicleType.Bus:
                return spot.Type == SpotType.Large && vehicle.RequiredSpots == 5; // Assuming buses need 5 large spots
            default:
                return false;
        }
    }
}