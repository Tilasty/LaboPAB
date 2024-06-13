using LaboPabApi.Entities;
using System.ServiceModel;

namespace LaboPabSoap.Service
{
    [ServiceContract]
    public interface IDepartmentService
    {
        [OperationContract]
        Task<string> AddDepartment(Department department);

        [OperationContract]
        Task<IEnumerable<Department>> GetDepartments();
    }
}