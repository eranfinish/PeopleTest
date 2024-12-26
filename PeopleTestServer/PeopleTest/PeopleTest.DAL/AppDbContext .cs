using PeopleTest.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PeopleTest.DAL
{
    public class AppDbContext : DbContext
    {
     

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
         public DbSet<Person> People { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(p => p.IdNumber)
                    .IsRequired()
                    .HasMaxLength(9);

                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(p => p.Email)
                    .HasMaxLength(200);

                entity.Property(p => p.BirthDate)
                    .IsRequired();

                entity.Property(p => p.Phone)
                    .HasMaxLength(20);
            });
        }

        // CRUD Operations

        // Create
        public async Task AddPersonAsync(Person person)
        {
            People.Add(person);
            await SaveChangesAsync();
        }

        // Read (Get all)
        public async Task<List<Person>> GetAllPeopleAsync()
        {
            return await People.ToListAsync();
        }

        // Read (Get by Id)
        public async Task<Person?> GetPersonByIdAsync(int id)
        {
            return await People.FindAsync(id);
        }

        // Update
        public async Task UpdatePersonAsync(Person person)
        {
            Entry(person).State = EntityState.Modified;
            await SaveChangesAsync();
        }

        // Delete
        public async Task DeletePersonAsync(int id)
        {
            var person = await People.FindAsync(id);
            if (person != null)
            {
                People.Remove(person);
                await SaveChangesAsync();
            }
        }
    }

}
