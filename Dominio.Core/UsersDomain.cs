using Domain.Interface;
using Dominio.Entity;
using Infraestructure.Interface;

namespace Domain.Core
{
    public class UsersDomain : IUsersDomain
    {
        #region Properties and Fields

        private readonly IUnitOfWork _unitOfWork;

        public UsersDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public Users Authenticate(string username, string password)
        {
            return _unitOfWork.Users.Authenticate(username, password);
        }

        #endregion
    }
}
