namespace locacaoVeicular.Entities
{
    class CarRental
    {
        public DateTime Start { get; set; }
        public DateTime Finsh { get; set; }
        public Vehicles Vehicles { get; set; }
        public Invoice Invoice { get; set; }

        public CarRental(DateTime start, DateTime finsh, Vehicles vehicles)
        {
            Start = start;
            Finsh = finsh;
            Vehicles = vehicles;
        }
    }
}
