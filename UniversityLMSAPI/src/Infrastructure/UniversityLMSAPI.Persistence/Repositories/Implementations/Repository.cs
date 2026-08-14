using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityLMSAPI.Persistence.Data;
using UniversityLMSAPI.Persistence.Repositories.Interface;

namespace UniversityLMSAPI.Persistence.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _entities;

        public Repository(AppDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }


        // Add a new entity of type T
        public async Task AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
        }

        // Retrieve all entities of type T
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.AsNoTracking().ToListAsync();
        }

        // Retrieve an entity of type T by its ID
        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _entities.FindAsync(id);
        }

        // Update an existing entity of type T
        public void UpdateAsync(T entity)
        {
            _entities.Update(entity);
        }

        // Delete an entity by its ID
        public async Task DeleteAsync(Guid id)
        {
            var entity = await _entities.FindAsync(id);
            if (entity != null)
            {
                _entities.Remove(entity);
            }
        }

        // Save changes to the database
        public void SaveChanges()
        {
           _context.SaveChanges();
        }
    }
}
