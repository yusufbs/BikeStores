
namespace ParkingLot.Two;

public class ParkingSpot
{
    private Vehicle vehicle;
    private VehicleSize spotSize;
    private int row;
    private int spotNumber;
    private Level level;

    public ParkingSpot(Level level, int row, int spotNumber, VehicleSize spotSize)
    {
        this.level = level;
        this.row = row;
        this.spotNumber = spotNumber;
        this.spotSize = spotSize;
        this.vehicle = null;
    }

    public bool isAvailable()
    {
        return vehicle == null;
    }

    public bool canFitVehicle(Vehicle vehicle)
    {
        return isAvailable() && vehicle.canFitInSpot(this);
    }

    public void parkVehicle(Vehicle vehicle)
    {
        if (canFitVehicle(vehicle))
        {
            this.vehicle = vehicle;
        }
    }

    public void removeVehicle()
    {
        this.vehicle = null;
    }

    public VehicleSize getSpotSize()
    {
        return spotSize;
    }

    public int getRow()
    {
        return row;
    }

    public int getSpotNumber()
    {
        return spotNumber;
    }

    public Vehicle getVehicle()
    {
        return vehicle;
    }
}