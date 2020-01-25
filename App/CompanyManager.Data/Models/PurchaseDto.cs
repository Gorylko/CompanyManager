namespace CompanyManager.Data.Models
{
    public class PurchaseDto
    {
        public int Id { get; set; }

        public int EnterpriseId { get; set; }

        public string Name { get; set; }

        public decimal? Cost { get; set; }

        public decimal? RentPrice { get; set; }

        public decimal? Income { get; set; }

        public virtual EnterpriseDto Enterprise { get; set; }
    }
}
