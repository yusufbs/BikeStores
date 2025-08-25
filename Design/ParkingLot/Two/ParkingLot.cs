namespace ParkingLot.Two;

public class ParkingLot
{
    private Level[] levels;

    public ParkingLot(int numLevels, int numSpotsPerLevel)
    {
        levels = new Level[numLevels];
        for (int i = 0; i < numLevels; i++)
        {
            levels[i] = new Level(i, numSpotsPerLevel);
        }
    }

    public bool parkVehicle(Vehicle vehicle)
    {
        foreach (Level level in levels)
        {
            if (level.parkVehicle(vehicle))
            {
                return true;
            }
        }
        return false; // Parking failed (no spots available)
    }

    public bool removeVehicle(Vehicle vehicle)
    {
        foreach (Level level in levels)
        {
            if (level.removeVehicle(vehicle))
            {
                return true;
            }
        }
        return false; // Removal failed (vehicle not found)
    }
}