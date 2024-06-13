using LaboPabApi.Entities;

namespace LaboPabSoap.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly List<Department> _departments = new List<Department>();

        public async Task<string> AddDepartment(Department department)
        {
            _departments.Add(department);
            return await Task.FromResult($"Department {department.Name} added!");
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await Task.FromResult(_departments);
        }
    }
}