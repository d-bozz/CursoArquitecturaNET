using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Cross.Common;
using Transversal.Common;

namespace Application.Interface
{
    public interface ICustomersApplication
    {
        #region Metodos Sincronos

        Response <bool> Insert(CustomersDTO customerDto);
        Response<bool> Update(CustomersDTO customerDto);
        Response<bool> Delete(string customerId);
        Response <CustomersDTO> Get(string customerId);
        Response <IEnumerable<CustomersDTO>> GetAll();
        ResponsePagination<IEnumerable<CustomersDTO>> GetAllWithPagination(int pageNumber, int pageSize);

        #endregion

        #region Metodos Asincronos

        Task<Response<bool>> InsertAsync(CustomersDTO customerDto);
        Task<Response<bool>> UpdateAsync(CustomersDTO customerDto);
        Task<Response<bool>> DeleteAsync(string customerId);
        Task<Response<CustomersDTO>> GetAsync(string customerId);
        Task<Response<IEnumerable<CustomersDTO>>> GetAllAsync();
        Task<ResponsePagination<IEnumerable<CustomersDTO>>> GetAllWithPaginationAsync(int pageNumber, int pageSize);

        #endregion
    }
}
