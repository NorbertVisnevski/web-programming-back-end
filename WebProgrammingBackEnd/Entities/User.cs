namespace WebProgrammingBackEnd.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int? HouseNumber { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public ICollection<Role> Roles { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
