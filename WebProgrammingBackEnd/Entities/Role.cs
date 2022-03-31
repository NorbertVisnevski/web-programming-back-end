using System.ComponentModel.DataAnnotations;

namespace WebProgrammingBackEnd.Entities
{
    public class Role
    {
        [Key]
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
