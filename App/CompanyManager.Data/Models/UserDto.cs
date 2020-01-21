namespace CompanyManager.Data.Models
{
    public class UserDto
    {
        public int Id { get; set; }

        public byte[] Password { get; set; }

        public string Email { get; set; }
    }
}
