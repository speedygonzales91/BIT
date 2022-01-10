using BIT_Models;

namespace BIT_Client.Service.IService
{
    public interface IProjectService
    {
        public Task<IEnumerable<ProjectDTO>> GetProjects();
        public Task<ProjectDTO> GetProject(int projectId);
        public Task<ProjectDTO> CreateProject(ProjectDTO project);
        public Task<ProjectDTO> UpdateProject(int projectId ,ProjectDTO project);
        public Task<int> DeleteProject(int projectId);
    }
}
