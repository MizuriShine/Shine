using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
	public DbSet<ShineTask> Tasks { get; set; }
	
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{
		
	}
}
