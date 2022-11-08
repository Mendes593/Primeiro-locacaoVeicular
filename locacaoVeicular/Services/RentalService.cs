using locacaoVeicular.Entities;
namespace locacaoVeicular.Services
{
    class RentalService
    {
        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }

        private ITaxservice _taxService;

        public RentalService(double pricePerHour, double pricePerDay, ITaxservice taxService)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            _taxService = taxService;
        }

        public void ProcessInvoice(CarRental carRental)
        {
            TimeSpan duration = carRental.Finsh.Subtract(carRental.Start);
            double basicPayment;
            if (duration.TotalHours <= 12.0)
            {
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);
            }
            else
            {
                basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
            }

            double tax = _taxService.Tax(basicPayment);
            carRental.Invoice = new Invoice(basicPayment, tax);
        }
    }
}