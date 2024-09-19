using Microsoft.EntityFrameworkCore;
using Moq;
using ProjectManagementApp.DataContext;
using ProjectManagementApp.Models;
using ProjectManagementApp.Services;
using Xunit;

namespace ProjectManagementApp.Test.UnitTest
{
    public class TaskServiceTest
    {
        [Fact]
        public async Task CreateTask_ShouldAddTaskToDatabase()
        {
            var options = new DbContextOptionsBuilder<ProjectManagementContext>()
                .UseInMemoryDatabase(databaseName: "ProjectManagementTestDatabase")
                .Options;

            using (var context = new ProjectManagementContext(options))
            {
                var service = new TaskService(context);
                var newTask = new TaskItem
                {
                    Name = "New Task",
                    Description = "Task Description",
                    DueDate = DateTime.UtcNow.AddDays(7),
                    Status = "ToDo"
                };

                var result = await service.CreateTaskAsync(newTask);

                Assert.NotNull(result);
                Assert.Equal("New Task", result.Name);
                Assert.Equal("Task Description", result.Description);
                Assert.Equal(1, await context.Tasks.CountAsync());
            }
        }
    }
}