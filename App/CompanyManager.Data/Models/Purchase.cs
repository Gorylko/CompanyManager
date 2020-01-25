namespace CompanyManager.Data.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        public int EnterpriseId { get; set; }

        public string Name { get; set; }

        public decimal? Cost { get; set; }

        public decimal? RentPrice { get; set; }

        public decimal? Income { get; set; }

        public virtual Enterprise Enterprise { get; set; }
    }
}
