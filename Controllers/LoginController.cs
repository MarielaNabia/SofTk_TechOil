using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SofTk_TechOil.DTOs;
using SofTk_TechOil.Helper;
using SofTk_TechOil.Services;

namespace SofTk_TechOil.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private JwtTokenHelper _jwtTokenHelper;
        private readonly IUnitOfWork _unitOfWork;
        public LoginController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _jwtTokenHelper = new JwtTokenHelper(configuration);
        }

        /// <summary>
        ///  Se loguea el usuario
        /// </summary>
        /// <returns>el token del usuario</returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AuthUserDto dto)
        {
            var userCredentials = await _unitOfWork.UserRepository.AuthenticateCredentials(dto);
            if (userCredentials is null) return Unauthorized("Las credenciales son incorrectas");

            var token = _jwtTokenHelper.CrearToken(userCredentials);

            var user = new UserLoginDto()
            {
                CodUsuario = userCredentials.CodUsuario,              
                Token = token
            };


            return Ok(user);

        }
    }
}
