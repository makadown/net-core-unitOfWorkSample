using unitOfWorkSample.Core;

namespace unitOfWorkSample.Persistence
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
{
    public IClientesRepository ClienteRepository { get; }

    public UnitOfWorkRepository(MySqlContext context)
    {
        ClienteRepository = new ClienteRepository(context);
    }
}
}