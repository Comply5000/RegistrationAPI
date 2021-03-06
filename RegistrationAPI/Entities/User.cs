namespace RegistrationAPI.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        
        public int AddressId { get; set; }
        
        public virtual Address Address { get; set; }
    }
}