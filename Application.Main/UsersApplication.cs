using Application.DTO;
using Application.Interface;
using Application.Validator;
using AutoMapper;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal.Common;

namespace Application.Main
{
    public class UsersApplication : IUsersApplication
    {
        #region Properties and fields

        private readonly IUsersDomain _usersDomain;
        private readonly IMapper _mapper;
        private readonly UsersDtoValidator _usersDtoValidator;

        public UsersApplication(IUsersDomain usersDomain, IMapper iMapper, UsersDtoValidator usersDtoValidator)
        {
            _usersDomain = usersDomain;
            _mapper = iMapper;
            _usersDtoValidator = usersDtoValidator;
        }

        #endregion

        #region Methods

        public Response<UsersDto> Authenticate(string username, string password)
        {
            var response = new Response<UsersDto>();
            var validation = _usersDtoValidator.Validate(new UsersDto() { UserName = username, Password = password });

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                return response;
            }
            try
            {
                var user = _usersDomain.Authenticate(username, password);
                response.Data = _mapper.Map<UsersDto>(user);
                response.IsSuccess = true;
                response.Message = "Autenticación Exitosa!!!";
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "Usuario no existe";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        #endregion
    }
}
