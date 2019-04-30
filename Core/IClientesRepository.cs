using unitOfWorkSample.Core.CrudAndPagination;
using unitOfWorkSample.Core.Models;

namespace unitOfWorkSample.Core
{
    /// <Summary>
    /// Agregar las interfaces de acuerdo al comportamiento que se desea para el repositorio.
    /// Por ejemplo, si nomás se quiere Crear y Leer, remover las demás interfaces.
    /// </Summary>
    public interface IClientesRepository: IPagedRepository<Clientes>, IReadRepository<Clientes>, 
            ICreateRepository<Clientes>, IRemoveRepository<Clientes>, IUpdateRepository<Clientes>
    {

    }

}