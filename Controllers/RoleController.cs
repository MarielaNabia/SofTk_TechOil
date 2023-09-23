using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SofTk_TechOil.DTOs;
using SofTk_TechOil.Entities;
using SofTk_TechOil.Services;

namespace SofTk_TechOil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        ///  Obtengo todos los roles
        /// </summary>
        /// <returns>devuelde todos los roles</returns>

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Role>>> GetAll()
        {
            var Roles = await _unitOfWork.RoleRepository.GetAll();

            return Roles;
        }


        /// <summary>
        ///  Inserta un rol
        /// </summary>
        /// <returns>Devuelve un mensaje de confirmacion del agrego del rol</returns>
        [Authorize(Policy = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Insert(RoleDto dto)
        {

            var Role = new Role(dto);
            await _unitOfWork.RoleRepository.Insert(Role);
            await _unitOfWork.Complete();
            return Ok(true);
        }


        /// <summary>
        ///  Actualiza un rol
        /// </summary>
        /// <returns>Devuelve un mensaje de actualizacion de rol</returns>

        [Authorize(Policy = "Admin")]
        [HttpPut("{id}")]

        public async Task<IActionResult> Update([FromRoute] int id, Role role)
        {
            var result = await _unitOfWork.RoleRepository.Update(role);

            await _unitOfWork.Complete();
            return Ok(true);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.RoleRepository.Delete(id);

            await _unitOfWork.Complete();
            return Ok(true);
        }
    }
}
