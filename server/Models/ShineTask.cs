using System.ComponentModel.DataAnnotations;

public class ShineTask
{
	[Key]
	public int Id { get; set; }
	[Required]
	public string Title { get; set; }
	public string Description { get; set; }
	public DateTime CreatedDate { get; set; } = DateTime.Now;
	public DateTime? UpdatedDate { get; set;}
}