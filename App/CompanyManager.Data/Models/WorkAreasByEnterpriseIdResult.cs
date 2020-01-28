namespace CompanyManager.Data.Models
{
    public class WorkAreasByEnterpriseIdResult
    {
        public int Id { get; set; }

        public int EnterpriseId { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public decimal? Cost { get; set; }

        public decimal? RentRrice { get; set; }
    }
}
