namespace ParkingLot.Two;

public class Ticket
{
    private Vehicle vehicle;
    private DateTime issueTime;
    private DateTime exitTime;

    public Ticket(Vehicle vehicle)
    {
        this.vehicle = vehicle;
        this.issueTime = new DateTime();
    }

    public void setExitTime(DateTime exitTime)
    {
        this.exitTime = exitTime;
    }

    public long getDuration()
    {
        TimeSpan timeSpan = exitTime - issueTime;
        return (long)timeSpan.TotalSeconds; // Time in seconds
    }
}