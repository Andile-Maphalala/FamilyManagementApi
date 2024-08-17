using FamilyManagement.Persistence.Data;
using FamilyManagement.Services.Middleware;
using FamilyManagement.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace FamilyManagement.Persistence.Repositories
{
    public class GenericRepository : IGenericRepository
    {
        private readonly FamilyManagementDbContext _dbContext;

        public GenericRepository(FamilyManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> Set<T>() where T : class
        {

            return _dbContext.Set<T>();
        }

        public async Task DeleteAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken) where T : class
        {
            var obj = await Set<T>().FirstOrDefaultAsync(predicate, cancellationToken);

            if (obj == null)
            {
                throw new BadRequestException("Record not found");
            }
            _dbContext.Remove(obj);
        }

        public async Task InsertAsync<T>(T entity, CancellationToken cancellationToken) where T : class
        {
            await _dbContext.AddAsync(entity);
        }

        public async Task UpdateAsync<T>(T entity, CancellationToken cancellationToken) where T : class
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
