namespace ParkingLot.One;

public class ParkingSpot
{
    public int SpotNumber { get; set; }
    public bool IsOccupied { get; private set; }
    public Vehicle? OccupiedByVehicle { get; private set; }
    public SpotType Type { get; private set; }

    public ParkingSpot(int spotNumber, SpotType type)
    {
        SpotNumber = spotNumber;
        Type = type;
        IsOccupied = false;
    }

    public bool ParkVehicle(Vehicle vehicle)
    {
        if (!IsOccupied)
        {
            IsOccupied = true;
            OccupiedByVehicle = vehicle;
            return true;
        }
        return false;
    }

    public bool RemoveVehicle()
    {
        if (IsOccupied)
        {
            IsOccupied = false;
            OccupiedByVehicle = null;
            return true;
        }
        return false;
    }
}
