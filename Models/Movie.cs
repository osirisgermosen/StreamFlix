using System.ComponentModel.DataAnnotations;

namespace MovieMvcProject.Models;

public class Movie
{
    public int Id { get; set; }
    public string? Title { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Release")]
    public DateTime ReleaseDate { get; set; }
    public string? Genre { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }
    public bool Active { get; set; }
}
