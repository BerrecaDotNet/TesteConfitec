using Microsoft.EntityFrameworkCore;
using TesteConfitec.Data.Context;

namespace TesteConfitec.Repositories.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TesteConfitecContext _context;
        public GenericRepository(TesteConfitecContext context)
        {
            _context = context;
        }
        public async Task Delete(int Id)
        {
           var entity = await GetById(Id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(int Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public async Task Insert(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int Id, T entity)
        {
            _context.Set<T>().Update(entity);  
            await _context.SaveChangesAsync();
        }
    }
}
