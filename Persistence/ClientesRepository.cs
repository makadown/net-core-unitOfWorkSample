using unitOfWorkSample.Core;
using unitOfWorkSample.Core.Models;

namespace unitOfWorkSample.Persistence
{
    public class ClienteRepository : GenericRepository<Clientes>, IClientesRepository
    {
        public ClienteRepository(MySqlContext context)
        {
            _context = context;
        }
    }
}