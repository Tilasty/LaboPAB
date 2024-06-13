using LaboPabApi.Entities;
using System.ServiceModel;

namespace LaboPabSoap.Service
{
    [ServiceContract]
    public interface IProjectService
    {
        [OperationContract]
        Task<string> AddProject(Project project);

        [OperationContract]
        Task<IEnumerable<Project>> GetProjects();
    }
}