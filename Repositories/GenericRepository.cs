using EmployeeRestAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeRestAPI.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private EmployeesContext _context;

        public GenericRepository(EmployeesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task InsertAsync(T obj)
        {
            _context.Set<T>().Add(obj);
            await Save();
        }

        public async Task UpdateAsync(T obj)
        {
            _context.Set<T>().Update(obj);
            await Save();
        }

        public async Task DeleteAsync(object employee)
        {
            _context.Remove(employee);
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
