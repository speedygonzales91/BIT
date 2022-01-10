using BIT_Models;

namespace BIT_Business.Repository.IRepository
{
    public interface IProjectRepository
    {
        public Task<ProjectDTO> CreateProject(ProjectDTO projectDTO);
        public Task<ProjectDTO> UpdateProject(int projectId, ProjectDTO projectDTO);
        public Task<int> DeleteProject(int projectId);
        public Task<ProjectDTO> GetProject(int projectId);
        public Task<IEnumerable<ProjectDTO>> GetAllProjects();
    }
}
