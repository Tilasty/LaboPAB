namespace LaboPabApi.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
