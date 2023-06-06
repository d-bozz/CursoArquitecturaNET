using Infraestructura.Interface;

namespace Infraestructure.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomersRepository Customers { get; }
        IUsersRepository Users { get; }
    }
}
