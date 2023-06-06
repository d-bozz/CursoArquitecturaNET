using Application.DTO;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Services.WebApi.Helpers;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Transversal.Common;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Services.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        #region Properties and Fields

        private readonly IUsersApplication _usersApplication;
        private readonly AppSettings _appSettings;

        public UsersController(IUsersApplication usersApplication, IOptions<AppSettings> appSettings)
        {
            _usersApplication = usersApplication;
            _appSettings = appSettings.Value;
        }

        #endregion

        #region Methods

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] UsersDto authDto)
        {
            var response = _usersApplication.Authenticate(authDto.UserName, authDto.Password);
            if (response.IsSuccess)
            {
                if (response.Data != null)
                {
                    response.Data.Token = BuildToken(response);
                    return Ok(response);
                }
                else
                {
                    return NotFound(response.Message);
                }
            }
            return BadRequest(response.Message);
        }

        private string BuildToken(Response<UsersDto> usersDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                { 
                    new Claim (ClaimTypes.Name, usersDto.Data.UserId.ToString())
                }),

                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience,
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }

        #endregion
    }
}
