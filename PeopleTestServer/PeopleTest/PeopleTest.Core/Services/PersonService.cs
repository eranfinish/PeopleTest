using PeopleTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleTest.DAL;

namespace PeopleTest.Core.Services
{
    public class PersonService : IPersonService
    {
        private readonly AppDbContext _context;

        public PersonService(AppDbContext context)
        {
            _context = context;
        }

        // Create
        public async Task AddPersonAsync(Person person)
        {
            try
            {
                _context.People.Add(person);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }


        // Read (Get All)
        public async Task<List<Person>> GetAllPeopleAsync()
        {
            var res = await _context.GetAllPeopleAsync();
            return res;
        }

        // Read (Get by Id)
        public async Task<Person?> GetPersonByIdAsync(int id)
        {
            return await _context.People.FindAsync(id);
        }

        // Update
        public async Task UpdatePersonAsync(Person person)
        {
            _context.People.Update(person);
            await _context.SaveChangesAsync();
        }

        // Delete
        public async Task DeletePersonAsync(int id)
        {
            var person = await _context.People.FindAsync(id);
            if (person != null)
            {
                _context.People.Remove(person);
                await _context.SaveChangesAsync();
            }
        }
    }

}
