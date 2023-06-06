using System;
using AutoMapper;
using Application.DTO;
using Application.Interface;
using Dominio.Entity;
using Dominio.Interface;
using Transversal.Common;
using System.Threading.Tasks;
using System.Collections.Generic;
using Cross.Common;

namespace Application.Main
{
    public class CustomersApplication : ICustomersApplication
    {
        #region Properties and Fields

        private readonly ICustomersDomain _customerDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CustomersApplication> _logger;

        public CustomersApplication(ICustomersDomain customerDomain, IMapper mapper, IAppLogger<CustomersApplication> logger)
        {
            _customerDomain = customerDomain;
            _mapper = mapper;
            _logger = logger;
        }

        #endregion

        #region Metodos Sincronos

        public Response<bool> Insert(CustomersDTO customerDto)
        { 
            var response = new Response<bool>();
            try 
            {
                var customer = _mapper.Map<Customers>(customerDto);
                response.Data = _customerDomain.Insert(customer);
                if (response.Data)
                { 
                    response.IsSuccess = true;
                    response.Message = "Registro exitoso!";
                }
            }
            catch (Exception ex) 
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public Response<bool> Update(CustomersDTO customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customerDto);
                response.Data = _customerDomain.Update(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualizacion exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public Response<bool> Delete(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = _customerDomain.Delete(customerId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminacion exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public Response<CustomersDTO> Get(string customerId)
        {
            var response = new Response<CustomersDTO>();
            try
            {
                var customer = _customerDomain.Get(customerId);
                response.Data = _mapper.Map<CustomersDTO>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "consulta exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public Response<IEnumerable<CustomersDTO>> GetAll()
        {
            var response = new Response<IEnumerable<CustomersDTO>>();
            try
            {
                var customers = _customerDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customers);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "consulta exitosa!";
                    _logger.LogInformation("consulta exitosa!");
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }
            return response;
        }
        public ResponsePagination<IEnumerable<CustomersDTO>> GetAllWithPagination(int pageNumber, int pageSize)
        {
            var response = new ResponsePagination<IEnumerable<CustomersDTO>>();
            try
            {
                var count = _customerDomain.Count();

                var customers = _customerDomain.GetAllWithPagination(pageNumber, pageSize);
                response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customers);

                if (response.Data != null)
                {
                    response.PageNumber = pageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                    response.TotalCount = count;
                    response.IsSuccess = true;
                    response.Message = "Consulta Paginada Exitosa!!!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        #endregion

        #region Metodos Asincronos

        public async Task<Response<bool>> InsertAsync(CustomersDTO customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customerDto);
                response.Data = await _customerDomain.InsertAsync(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro exitoso!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<bool>> UpdateAsync(CustomersDTO customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customerDto);
                response.Data = await _customerDomain.UpdateAsync(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualizacion exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<bool>> DeleteAsync(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _customerDomain.DeleteAsync(customerId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminacion exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<CustomersDTO>> GetAsync(string customerId)
        {
            var response = new Response<CustomersDTO>();
            try
            {
                var customer = await _customerDomain.GetAsync(customerId);
                response.Data = _mapper.Map<CustomersDTO>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "consulta exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<IEnumerable<CustomersDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CustomersDTO>>();
            try
            {
                var customers = await _customerDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customers);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "consulta exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<ResponsePagination<IEnumerable<CustomersDTO>>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            var response = new ResponsePagination<IEnumerable<CustomersDTO>>();
            try
            {
                var count = await _customerDomain.CountAsync();

                var customers = await _customerDomain.GetAllWithPaginationAsync(pageNumber, pageSize);
                response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customers);

                if (response.Data != null)
                {
                    response.PageNumber = pageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                    response.TotalCount = count;
                    response.IsSuccess = true;
                    response.Message = "Consulta Paginada Exitosa!!!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        #endregion
    }
}