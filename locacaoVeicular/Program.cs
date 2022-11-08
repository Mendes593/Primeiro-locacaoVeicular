using locacaoVeicular.Services;
using System.Globalization;
using locacaoVeicular.Entities;

namespace locacaoVeicular
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Rental Data");
            Console.WriteLine("Car model: ");
            string model = Console.ReadLine();
            Console.WriteLine("Pickup (dd/mm/yyyy hh:mm)");
            DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.WriteLine("Retourn (dd/mm/yyyy hh:mm)");
            DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.WriteLine("Enter Price per Hour: ");
            double hour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine("Enter Price per Day: ");
            double day = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);


            CarRental carRental = new CarRental(start, finish, new Vehicles(model));

            RentalService rentalService = new RentalService(hour, day, new BrazilTaxService());

            rentalService.ProcessInvoice(carRental);
            Console.WriteLine("Invoice: ");
            Console.WriteLine(carRental.Invoice);
        }
    }
}
