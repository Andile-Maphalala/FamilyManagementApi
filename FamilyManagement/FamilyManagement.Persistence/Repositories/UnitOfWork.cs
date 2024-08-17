

using FamilyManagement.Persistence.Data;
using FamilyManagement.Services.Repositories;

namespace FamilyManagement.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FamilyManagementDbContext _context;
        private IFamilyManagementRepository _repository;

        public UnitOfWork(FamilyManagementDbContext context)
        {
            _context = context;
        }

        public IFamilyManagementRepository Repository => _repository ??= new FamilyManagementRepository(_context);

        public async Task Save(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

