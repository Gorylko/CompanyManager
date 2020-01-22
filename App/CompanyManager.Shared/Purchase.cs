namespace CompanyManager.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; }

        public decimal RentCost { get; set; }

        public decimal Income { get; set; }
    }
}
