namespace CompanyManager.Models
{
    public class WorkArea
    {
        public int Id { get; set; }

        public int EnterpriseId { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public decimal? Cost { get; set; }

        public decimal? RentRrice { get; set; }

        public virtual Enterprise Enterprise { get; set; }
    }
}
