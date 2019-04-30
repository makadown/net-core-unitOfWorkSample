namespace unitOfWorkSample.Core
{
    public interface IUnitOfWorkRepository
    {
        // Agregar aquí todos los repositorios necesarios para el UoW
        IClientesRepository ClienteRepository { get; }
    }
}