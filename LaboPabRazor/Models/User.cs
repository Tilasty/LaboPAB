namespace LaboPabRazor.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public User UserRole { get; set; }
    }
}
