using System.ComponentModel.DataAnnotations;

namespace LaboPabRazor.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Admin AdminRole { get; set; }
    }
}
