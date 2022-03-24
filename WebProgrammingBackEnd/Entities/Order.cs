namespace WebProgrammingBackEnd.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public double Total { get; set; }
        public string Status { get; set; }
        public DateTime OrderTime { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string ZipCode { get; set; }
        public ICollection<SubOrder> SubOrders { get; set; }
        //public int BuyerId { get; set; }
        //public User Buyer { get; set; }
    }
}
