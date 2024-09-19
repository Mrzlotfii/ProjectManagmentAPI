using ProjectManagementApp.Models;

namespace ProjectManagementApp.Services.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskItem>> GetTasksByProjectIdAsync(int projectId);
        Task<TaskItem> CreateTaskAsync(TaskItem task);
        Task UpdateTaskStatusAsync(int taskId, string status);
        Task DeleteTaskAsync(int taskId);
    }
}
