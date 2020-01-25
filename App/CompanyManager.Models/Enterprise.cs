namespace CompanyManager.Models
{
    public class Enterprise
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public User Author { get; set; }
    }
}
