using System.ComponentModel.DataAnnotations;

public class Project
{
	[Key]
	public int Id { get; set; }
	[Required]
	[MaxLength(100)]
	public required string Title { get; set; }
	public string? Description { get; set; }
	public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
	public DateTime? UpdatedDate { get; set; }
}