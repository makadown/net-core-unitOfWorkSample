using unitOfWorkSample.Core;
using unitOfWorkSample.Core.Models;

namespace unitOfWorkSample.Persistence
{
    public class ClienteRepository : GenericRepository<Clientes>, IClientesRepository
    {
        // private readonly MySqlContext _context;
        public ClienteRepository(MySqlContext context)
        {
            _context = context;
        }
    }
}