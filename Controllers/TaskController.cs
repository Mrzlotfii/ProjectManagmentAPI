using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagementApp.DataContext;
using ProjectManagementApp.Models;
using ProjectManagementApp.Services.Interfaces;

namespace ProjectManagementApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly IProjectService _projectService;
    private readonly ProjectManagementContext _context;

    public TaskController(ProjectManagementContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] TaskItem task)
    {
        if (task == null)
        {
            return BadRequest("Task cannot be null");
        }

        var projectExists = await _context.Projects.AnyAsync(x => x.Id == task.ProjectId);
        if (!projectExists)
        {
            return NotFound($"Project with ID {task.ProjectId} does not exist in Db.");
        }

        _context.Tasks.Add(task);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, "An error occurred while saving the task.");
        }

        return CreatedAtAction(nameof(CreateTask), new { id = task.Id }, task);

    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskItem>>> ListTasks(int projectId)
    {
        return await _context.Tasks.Where(x => x.ProjectId == projectId).ToListAsync();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTaskStatus(int projectId, int id, [FromBody] string status)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null || task.ProjectId != projectId)
            return NotFound();

        task.Status = status;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int projectId, int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null || task.ProjectId != projectId)
            return NotFound();

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
