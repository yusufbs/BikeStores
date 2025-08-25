namespace ParkingLot.One
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            CheckParkingLotOne();

            CheckParkingLotTwo();

        }

        private static void CheckParkingLotTwo()
        {
            throw new NotImplementedException();
        }

        private static void CheckParkingLotOne()
        {
            var parkingLot = new ParkingLot(10, 20, 5);

            parkingLot.ParkVehicle(new Car { LicensePlate = "CAR123", EntryTime = DateTime.Now });
            parkingLot.ParkVehicle(new Motorcycle { LicensePlate = "MOTO123", EntryTime = DateTime.Now });
            parkingLot.ParkVehicle(new Bus { LicensePlate = "BUS123", EntryTime = DateTime.Now });
            //parkingLot.UnparkVehicle("CAR123");
            //parkingLot.UnparkVehicle("MOTO123");
            //parkingLot.UnparkVehicle("BUS123");

            // Uncomment the following line to test parking a vehicle that doesn't fit
            parkingLot.ParkVehicle(new CarWith3Spots { LicensePlate = "CAR456", EntryTime = DateTime.Now });

            // Additional test cases can be added here
            Console.WriteLine("Parking lot operations completed.");
            // Keep the console window open
            Console.ReadLine();
        }
    }
}
