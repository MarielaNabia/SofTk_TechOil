using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SofTk_TechOil.DTOs;
using SofTk_TechOil.Entities;
using SofTk_TechOil.Helper;
using SofTk_TechOil.Infrastructure;
using SofTk_TechOil.Services;

namespace SofTk_TechOil.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public JobController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        /// Obtiene una lista paginada de todos los trabajos.
        /// </summary>
        /// <returns>Una respuesta HTTP que contiene la lista de trabajos paginada.</returns>
        [HttpGet]
        [Route("Job")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var trabajos = await _unitOfWork.JobRepository.GetAllAsync();
                int pageToShow = 1;

                if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);

                var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();

                // Mapea los trabajos a DTOs sin las propiedades de navegación ciclicas
                var trabajosDto = trabajos.Select(j => new AddJobDto
                {
                    CodTrabajo = j.CodTrabajo,
                    Fecha = j.Fecha,
                    CodProyecto = j.CodProyecto,
                    ProjectNombre = j.Project?.Nombre, // Incluye el nombre del proyecto
                    CodServicio = j.CodServicio,
                    ServiceDescripcion = j.Service?.Descripcion, // Incluye la descripción del servicio
                    CantHoras = j.CantHoras,
                    ValorHora = j.ValorHora,
                    Costo = j.Costo,
                    Activo = j.Activo
                }).ToList();

                var paginateTrabajos = PaginateHelper.Paginate(trabajosDto, pageToShow, url);

                return ResponseFactory.CreateSuccessResponse(200, paginateTrabajos);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, $"Error al obtener la lista de trabajos: {ex.Message}");
            }
        }
    

        /// <summary>
        /// Obtiene un trabajo por su ID.
        /// </summary>
        /// <param name="id">ID del trabajo a obtener.</param>
        /// <returns>Una respuesta HTTP que contiene el trabajo encontrado o un mensaje de not found.</returns>

        [HttpGet("JobById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var trabajo = await _unitOfWork.JobRepository.GetByIdAsync(id);

                if (trabajo == null)
                {
                    return NotFound();
                }

                return ResponseFactory.CreateSuccessResponse(200, trabajo);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, $"Error al obtener el trabajo por ID: {ex.Message}");
            }
        }

        /// <summary>
        /// Crea un nuevo trabajo.
        /// </summary>
        /// <param name="dto">Datos del nuevo trabajo.</param>
        /// <returns>Una respuesta HTTP que indica el resultado de la operación.</returns>

        //[Authorize(Policy = "Admin")]
        [HttpPost]
        [Route("NewTrabajo")]
        public async Task<IActionResult> CreateAsync(AddJobDto dto)
        {
            try
            {
                var job = new Job(dto);
                await _unitOfWork.JobRepository.CreateAsync(job);
                await _unitOfWork.Complete();

                return ResponseFactory.CreateSuccessResponse(201, "trabajo creado con éxito");
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, $"Error al crear el trabajo: {ex.Message}");
            }
        }

        /// <summary>
        /// Actualiza un trabajo existente por su ID.
        /// </summary>
        /// <param name="id">ID del trabajo a actualizar.</param>
        /// <param name="dto">Datos del trabajo actualizado.</param>
        /// <returns>Una respuesta HTTP que indica el resultado de la operación.</returns>
        //[Authorize(Policy = "Admin")]
        [HttpPut("Editar/{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, AddJobDto dto)
        {
            try
            {
                var updatedJob = new Job(dto, id);

                var result = await _unitOfWork.JobRepository.UpdateAsync(updatedJob);

                await _unitOfWork.Complete();

                if (result)
                {
                    return Ok(true);
                }
                else
                {
                    return ResponseFactory.CreateErrorResponse(400, "No se pudo actualizar el trabajo.");
                }
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, $"Error al actualizar el trabajo: {ex.Message}");
            }

        }

        /// <summary>
        /// Realiza una eliminación lógica de un trabajo por su ID.
        /// </summary>
        /// <param name="id">ID del trabajo a eliminar.</param>
        /// <returns>Una respuesta HTTP que indica el resultado de la operación.</returns>
        [Authorize(Policy = "Admin")]
        [HttpPut("DeleteLogico/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var result = await _unitOfWork.JobRepository.DeleteAsync(id);
                await _unitOfWork.Complete();

                if (result)
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest("No se pudo eliminar el trabajo.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el trabajo: {ex.Message}");
            }
        }


    }
}
