using Microsoft.EntityFrameworkCore;
using ProjectManagementApp.DataContext;
using ProjectManagementApp.Models;
using ProjectManagementApp.Services.Interfaces;

namespace ProjectManagementApp.Services
{
    /// <summary>
    /// Task Managment Services
    /// </summary>
    public class TaskService : ITaskService
    {
        private readonly ProjectManagementContext _context;

        public TaskService(ProjectManagementContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TaskItem>> GetTasksByProjectIdAsync(int projectId)
        {
            return await _context.Tasks.Where(x => x.ProjectId == projectId).ToListAsync();
        }

        public async Task<TaskItem> CreateTaskAsync(TaskItem task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task UpdateTaskStatusAsync(int taskId, string status)
        {
            var task = await _context.Tasks.FindAsync(taskId);
            if (task != null)
            {
                task.Status = status;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTaskAsync(int taskId)
        {
            var task = await _context.Tasks.FindAsync(taskId);
            if (task != null)
            {
                await _context.Tasks.AddAsync(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}
