using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;
using unitOfWorkSample.Core;

namespace unitOfWorkSample.Persistence
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly MySqlContext _context;
        public UnitOfWork(IUnitOfWorkRepository repository) 
        {
            this.Repository = repository;
               
        }
        public IUnitOfWorkRepository Repository { get; }

        public UnitOfWork(MySqlContext context
        )
        {
            _context = context;
            Repository = new UnitOfWorkRepository(_context);
        }

        #region Detect Changes
        public void DetectChanges()
        {
            _context.ChangeTracker.DetectChanges();
        }
        #endregion

        #region Save Changes
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Transactions
        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            _context.Database.RollbackTransaction();
        }
        #endregion
    }
}