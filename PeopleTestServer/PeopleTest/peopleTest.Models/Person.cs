using System.ComponentModel.DataAnnotations;

namespace PeopleTest.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string IdNumber { get; set; } = String.Empty;
        [Required]
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
    }
}
