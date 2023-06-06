using Microsoft.AspNetCore.Mvc;
using Application.DTO;
using Application.Interface;
using Microsoft.AspNetCore.Authorization;

namespace Services.WebApi.Controllers
{
    [Authorize]
    [Route("api[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        #region Properties and Fields

        private readonly ICustomersApplication _customerApplication;

        public CustomersController(ICustomersApplication customerApplication)
        {
            _customerApplication = customerApplication;
        }

        #endregion

        #region Metodos Sincronos

        [HttpPost("Insert")]
        public IActionResult Insert([FromBody]CustomersDTO customerDTO)
        { 
            if (customerDTO == null)
            {
                return BadRequest();
            }

            var response = _customerApplication.Insert(customerDTO);

            return response.IsSuccess ? Ok(response) : BadRequest(response.Message);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] CustomersDTO customerDTO)
        {
            if (customerDTO == null)
            {
                return BadRequest();
            }

            var response = _customerApplication.Update(customerDTO);

            return response.IsSuccess ? Ok(response) : BadRequest(response.Message);
        }

        [HttpDelete("Delete/{customerId}")]
        public IActionResult Delete(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return BadRequest();
            }

            var response = _customerApplication.Delete(customerId);

            return response.IsSuccess ? Ok(response) : BadRequest(response.Message);
        }

        [HttpGet("Get/{customerId}")]
        public IActionResult Get(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return BadRequest();
            }

            var response = _customerApplication.Get(customerId);

            return response.IsSuccess ? Ok(response) : BadRequest(response.Message);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {

            var response = _customerApplication.GetAll();

            return response.IsSuccess ? Ok(response) : BadRequest(response.Message);
        }

        #endregion

        #region Metodos Sincronos

        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody] CustomersDTO customerDTO)
        {
            if (customerDTO == null)
            {
                return BadRequest();
            }

            var response = await _customerApplication.InsertAsync(customerDTO);

            return response.IsSuccess ? Ok(response) : BadRequest(response.Message);
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] CustomersDTO customerDTO)
        {
            if (customerDTO == null)
            {
                return BadRequest();
            }

            var response = await _customerApplication.UpdateAsync(customerDTO);

            return response.IsSuccess ? Ok(response) : BadRequest(response.Message);
        }

        [HttpDelete("DeleteAsync/{customerId}")]
        public async Task<IActionResult> DeleteAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return BadRequest();
            }

            var response = await _customerApplication.DeleteAsync(customerId);

            return response.IsSuccess ? Ok(response) : BadRequest(response.Message);
        }

        [HttpGet("GetAsync/{customerId}")]
        public async Task<IActionResult> GetAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return BadRequest();
            }

            var response = await _customerApplication.GetAsync(customerId);

            return response.IsSuccess ? Ok(response) : BadRequest(response.Message);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {

            var response = await _customerApplication.GetAllAsync();

            return response.IsSuccess ? Ok(response) : BadRequest(response.Message);
        }

        #endregion
    }
}
