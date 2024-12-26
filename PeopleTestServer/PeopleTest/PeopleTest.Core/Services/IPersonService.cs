using PeopleTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleTest.Core.Services
{
    public interface IPersonService
    {
        Task AddPersonAsync(Person person);
        Task<List<Person>> GetAllPeopleAsync();
        Task<Person?> GetPersonByIdAsync(int id);
        Task UpdatePersonAsync(Person person);
        Task DeletePersonAsync(int id);
      

    }
}
