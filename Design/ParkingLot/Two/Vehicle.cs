using ParkingLot.One;

namespace ParkingLot.Two;

public abstract class Vehicle
{
    protected String licensePlate;
    protected int spotsNeeded;
    protected VehicleSize size;

    public Vehicle(String licensePlate, VehicleSize size)
    {
        this.licensePlate = licensePlate;
        this.size = size;
        this.spotsNeeded = (size == VehicleSize.Large) ? 5 : 1;
    }

    public int getSpotsNeeded()
    {
        return spotsNeeded;
    }

    public VehicleSize getSize()
    {
        return size;
    }

    public String getLicensePlate()
    {
        return licensePlate;
    }

    public abstract bool canFitInSpot(ParkingSpot spot);
}
