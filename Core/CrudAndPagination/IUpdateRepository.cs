using System.Collections.Generic;
using System.Threading.Tasks;

namespace unitOfWorkSample.Core.CrudAndPagination
{
    public interface IUpdateRepository<T> where T : class
    {
        void Update(T t);
        void Update(IEnumerable<T> t);
    }
}