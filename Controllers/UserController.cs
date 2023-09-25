using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SofTk_TechOil.DTOs;
using SofTk_TechOil.Entities;
using SofTk_TechOil.Helper;
using SofTk_TechOil.Infrastructure;
using SofTk_TechOil.Services;

namespace SofTk_TechOil.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        ///  Devuelve todo los usuarios
        /// </summary>
        /// <returns>retorna todos los usuarios</returns>
        [Authorize(Policy = "AdminConsultor")]
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            var usersDto = users.Select(j => new RegisterDto
            {
                CodUsuario=j.CodUsuario,
                Nombre=j.Nombre,    
                DNI=j.DNI,
                Password =j.Password,
                RoleId=j.RoleId
            }).ToList();
            int pageToShow = 1;

            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);

            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();

            var paginateUsers = PaginateHelper.Paginate(usersDto, pageToShow, url);

            return ResponseFactory.CreateSuccessResponse(200, paginateUsers);
        }

        /// <summary>
        /// Obtiene un usuario por su ID.
        /// </summary>
        /// <param name="id">El ID del usuario a obtener.</param>
        /// <returns>El usuario encontrado.</returns>
        [Authorize(Policy = "AdminConsultor")]
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);

            if (user == null)
            {
                return ResponseFactory.CreateErrorResponse(404, $"Usuario con ID {id} no encontrado.");
            }

            return ResponseFactory.CreateSuccessResponse(200, user);
        }

        /// <summary>
        ///  Registra el usuario
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>devuelve un usuario registrado con un statusCode 201</returns>

        [Authorize(Policy = "Admin")]
        [HttpPost]
        [Route("Alta")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {

            if (await _unitOfWork.UserRepository.UserEx(dto.CodUsuario)) return ResponseFactory.CreateErrorResponse(409, $"Ya existe un usuario registrado con el usuario:{dto.CodUsuario}");
            var user = new User(dto);
            await _unitOfWork.UserRepository.CreateAsync(user);
            await _unitOfWork.Complete();

            return ResponseFactory.CreateSuccessResponse(201, "Usuario registrado con exito!");
        }

        /// <summary>
        ///  Actualiza el usuario
        /// </summary>
        /// <returns>actualizado o un 500</returns>
        [Authorize(Policy = "Admin")]
        [HttpPut("Modificar/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, RegisterDto dto)
        {

            var result = await _unitOfWork.UserRepository.UpdateAsync(new User(dto, id));

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo eliminar el usuario");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "ok.Actualizado");
            }
        }


        /// <summary>
        ///  Elimina el usuario
        /// </summary>
        /// <returns>Eliminado o un 500</returns>
        [Authorize(Policy = "Admin")]
        [HttpPut("Baja/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.UserRepository.DeleteAsync(id);

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo eliminar el usuario");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Eliminado");
            }
        }

    }
}
