using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models;

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    [Display(Name = "Date Of Birth")]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
    public string? Login { get; set; }
    [Display(Name = "Is Deleted?")]
    public bool IsDeleted { get; set; }
}