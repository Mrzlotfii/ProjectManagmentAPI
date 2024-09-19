using ProjectManagementApp.Models;

namespace ProjectManagementApp.Services.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(int projectId);
        Task<Project> CreateProjectAsync(Project project);
        Task DeleteProjectAsync(int projectId);
    }
}
