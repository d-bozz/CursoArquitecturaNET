using Dominio.Entity;
using Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Interface
{
    public interface IUsersRepository : IGenericRepository<Users>
    {
        Users Authenticate(string username, string password);
    }
}
