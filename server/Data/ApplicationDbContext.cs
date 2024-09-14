using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
	public DbSet<Project> Projects { get; set; }
	public DbSet<ShineTask> Tasks { get; set; }
	public override DbSet<ApplicationUser> Users { get; set; }

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{

	}
}
