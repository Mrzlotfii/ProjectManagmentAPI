using Microsoft.EntityFrameworkCore;
using ProjectManagementApp.DataContext;
using ProjectManagementApp.Models;
using ProjectManagementApp.Services.Interfaces;

namespace ProjectManagementApp.Services
{
    /// <summary>
    /// Project Managment Services
    /// </summary>
    public class ProjectService : IProjectService
    {
        private readonly ProjectManagementContext _context;

        public ProjectService(ProjectManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _context.Projects.Include(x => x.Tasks).ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int projectId)
        {
            return await _context.Projects.Include(x => x.Tasks).FirstOrDefaultAsync(x => x.Id == projectId);
        }

        public async Task<Project> CreateProjectAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task DeleteProjectAsync(int projectId)
        {
            var project = await _context.Projects.FindAsync(projectId);
            if (project != null)
            {
                await _context.Projects.AddAsync(project);
                await _context.SaveChangesAsync();
            }
        }
    }
}
