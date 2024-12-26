using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleTest.DAL.DTO
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string IdNumber { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
    }
}
