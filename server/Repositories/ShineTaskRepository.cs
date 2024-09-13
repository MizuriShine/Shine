using Microsoft.EntityFrameworkCore;

public interface IShineTaskRepository
{
	Task<IEnumerable<ShineTask>> GetAllTasksAsync();
	Task<ShineTask?> GetTaskByIdAsync(int id);
	Task CreateTaskAsync(ShineTask task);
	Task UpdateTaskAsync(ShineTask task);
	Task DeleteTaskAsync(int id);
}

public class ShineTaskRepository : IShineTaskRepository
{
	private readonly ApplicationDbContext _dbContext;

	public ShineTaskRepository(ApplicationDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<IEnumerable<ShineTask>> GetAllTasksAsync()
	{
		return await _dbContext.Tasks.ToListAsync();
	}

	public async Task<ShineTask?> GetTaskByIdAsync(int id)
	{
		return await _dbContext.Tasks.FindAsync(id);
	}

	public async Task CreateTaskAsync(ShineTask task)
	{
		await _dbContext.Tasks.AddAsync(task);
		await _dbContext.SaveChangesAsync();
	}

	public async Task UpdateTaskAsync(ShineTask task)
	{
		_dbContext.Tasks.Update(task);
		await _dbContext.SaveChangesAsync();
	}

	public async Task DeleteTaskAsync(int id)
	{
		var task = await _dbContext.Tasks.FindAsync();
		
		if (task != null)
		{
			_dbContext.Remove(task);
			await _dbContext.SaveChangesAsync();
		}
	}
}