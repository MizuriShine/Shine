using System.ComponentModel.DataAnnotations;

public class ProjectDto
{
    [Required]
    public required string Title { get; set; }
    public string? Description { get; set; }
}