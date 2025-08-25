namespace ParkingLot.Two;

public class PaymentService
{
    public double calculateFee(Ticket ticket)
    {
        long duration = ticket.getDuration();
        // Simple fee model: $1 per hour
        return duration / 3600.0;
    }

    public void processPayment(Ticket ticket)
    {
        double fee = calculateFee(ticket);
        Console.WriteLine("Payment processed for $" + fee);
    }
}