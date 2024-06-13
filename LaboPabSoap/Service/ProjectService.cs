using LaboPabApi.Entities;

namespace LaboPabSoap.Service
{
    public class ProjectService : IProjectService
    {
        private readonly List<Project> _projects = new List<Project>();

        public async Task<string> AddProject(Project project)
        {
            _projects.Add(project);
            return await Task.FromResult($"Project {project.Title} added!");
        }

        public async Task<IEnumerable<Project>> GetProjects()
        {
            return await Task.FromResult(_projects);
        }
    }
}