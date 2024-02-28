
using Microsoft.EntityFrameworkCore;
using PatientPortal.Data;
using PatientPortal.Entity;

namespace PatientPortal.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbSet<T> _dbSet;
        private readonly MyDbContext _myDbContext;

        public Repository(MyDbContext myDbContext)
        {
            _dbSet = myDbContext.Set<T>();
            _myDbContext = myDbContext;
        }     
        public async Task<T> AddAsync(T entity)
        {
            await _myDbContext.AddAsync(entity);
            await _myDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _myDbContext.SaveChangesAsync();
        }

        public Task<T> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(PatientsInformation patient)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);  
            _myDbContext.Entry(entity).State = EntityState.Modified;
            await _myDbContext.SaveChangesAsync();
        }

        Task<T> IRepository<T>.UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
