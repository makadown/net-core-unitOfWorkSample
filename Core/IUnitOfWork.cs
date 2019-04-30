using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace unitOfWorkSample.Core
{
    /// <Summary>
    /// Esta es la interfaz "principal" que se usaria.
    /// </Summary>
    public interface IUnitOfWork
    {
        void DetectChanges();
        void SaveChanges();
        Task SaveChangesAsync();
        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();
        void CommitTransaction();
        void RollbackTransaction();

        IUnitOfWorkRepository Repository { get; }
    }
}