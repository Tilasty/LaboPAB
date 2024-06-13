namespace LaboPabApi.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public Department Department { get; set; }
        public ICollection<Project> Projects { get; set; }
    }

}
