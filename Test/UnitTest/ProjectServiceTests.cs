using Microsoft.EntityFrameworkCore;
using Moq;
using ProjectManagementApp.DataContext;
using ProjectManagementApp.Models;
using ProjectManagementApp.Services;
using Xunit;

namespace ProjectManagementApp.Tests.Test.UnitTest
{
    public class ProjectServiceTests
    {
        private readonly ProjectManagementContext _context;
        private readonly ProjectService _projectService;

        public ProjectServiceTests()
        {
            var options = new DbContextOptionsBuilder<ProjectManagementContext>()
                .UseInMemoryDatabase(databaseName: "ProjectManagementTestDatabase")
                .Options;

            _context = new ProjectManagementContext(options);
            _projectService = new ProjectService(_context);
        }

        [Fact]
        public async Task AddProject_ShouldAddProject()
        {
            var project = new Project { Name = "Test Project", Description = "Test Description" };
            var result = await _projectService.CreateProjectAsync(project);

            Assert.NotNull(result);
            Assert.Equal("Test Project", result.Name);
            Assert.Equal("Test Description", result.Description);

            var projectInDb = await _context.Projects.FirstOrDefaultAsync(p => p.Id == result.Id);
            Assert.NotNull(projectInDb);
            Assert.Equal("Test Project", projectInDb.Name);
        }
    }
}
