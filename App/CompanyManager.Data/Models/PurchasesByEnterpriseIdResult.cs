namespace CompanyManager.Data.Models
{
    public class PurchasesByEnterpriseIdResult
    {
        public int Id { get; set; }

        public int EnterpriseId { get; set; }

        public string Name { get; set; }

        public decimal? Cost { get; set; }

        public decimal? RentPrice { get; set; }

        public decimal? Income { get; set; }
    }
}
