using System;
using System.Threading.Tasks;

namespace unitOfWorkSample.Core {
    public interface IUnitOfWork
	{
		IGenericRepository<T> Repository<T>() where T : class;

		Task<int> Commit();

		void Rollback();
	}
}