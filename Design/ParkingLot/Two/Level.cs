namespace ParkingLot.Two;

public class Level
{
    private int levelNumber;
    private ParkingSpot[] spots;

    public Level(int levelNumber, int numSpots)
    {
        this.levelNumber = levelNumber;
        this.spots = new ParkingSpot[numSpots];
    }

    public bool parkVehicle(Vehicle vehicle)
    {
        foreach (ParkingSpot spot in spots)
        {
            if (spot.canFitVehicle(vehicle))
            {
                spot.parkVehicle(vehicle);
                return true;
            }
        }
        return false;
    }

    public bool removeVehicle(Vehicle vehicle)
    {
        foreach (ParkingSpot spot in spots)
        {
            if (!spot.isAvailable() && spot.getVehicle() == vehicle)
            {
                spot.removeVehicle();
                return true;
            }
        }
        return false;
    }
}