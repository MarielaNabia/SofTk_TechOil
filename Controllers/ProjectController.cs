﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SofTk_TechOil.DTOs;
using SofTk_TechOil.Entities;
using SofTk_TechOil.Helper;
using SofTk_TechOil.Infrastructure;
using SofTk_TechOil.Services;
using static SofTk_TechOil.Entities.Project;

namespace SofTk_TechOil.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Obtiene una lista paginada de todos los projectos.
        /// </summary>
        /// <returns>Una respuesta HTTP que contiene la lista de projectos paginada.</returns>
        [HttpGet]
        [Authorize(Policy = "AdminConsultor")]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var proyectos = await _unitOfWork.ProjectRepository.GetAllAsync();
                int pageToShow = 1;

                if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);

                var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
                var paginateProyectos = PaginateHelper.Paginate(proyectos, pageToShow, url);

                return ResponseFactory.CreateSuccessResponse(200, paginateProyectos);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, $"Error al obtener la lista de proyectos: {ex.Message}");
            }
        }

        //// <summary>
        /// Obtiene proyectos por estado.
        /// </summary>
        /// <param name="estado">Estado del proyecto (Pendiente, Confirmado o Terminado).</param>
        /// <returns>Lista de proyectos que coinciden con el estado especificado.</returns>
        [Authorize(Policy = "AdminConsultor")]
        [HttpGet("GetByEstado/{estado}")]
        public async Task<IActionResult> GetEstadoProjects(EstadoTrabajo estado)
        {
            try
            {
                var proyectos = await _unitOfWork.ProjectRepository.GetEstadoProjectsAsync(estado);

                return ResponseFactory.CreateSuccessResponse(200, proyectos);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, $"Error al obtener la lista de projectos activos: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtiene un servicio por su ID.
        /// </summary>
        /// <param name="id">ID del servicio a obtener.</param>
        /// <returns>Una respuesta HTTP que contiene el servicio encontrado o un mensaje de not found.</returns>
        [Authorize(Policy = "AdminConsultor")]
        [HttpGet("ProjectById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var servicio = await _unitOfWork.ProjectRepository.GetByIdAsync(id);

                if (servicio == null)
                {
                    return NotFound();
                }

                return ResponseFactory.CreateSuccessResponse(200, servicio);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, $"Error al obtener el ID: {ex.Message}");
            }
        }

        /// <summary>
        /// Crea un nuevo servicio.
        /// </summary>
        /// <param name="dto">Datos del nuevo servicio.</param>
        /// <returns>Una respuesta HTTP que indica el resultado de la operación.</returns>

        [Authorize(Policy = "Admin")]
        [HttpPost]
        [Route("Alta")]
        public async Task<IActionResult> NewProject(AddProjectDto dto)
        {
            try
            {
                var project = new Project(dto);
                await _unitOfWork.ProjectRepository.CreateAsync(project);
                await _unitOfWork.Complete();

                return ResponseFactory.CreateSuccessResponse(201, "Creado con éxito");
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, $"Error en el alta: {ex.Message}");
            }
        }

        /// <summary>
        /// Actualiza un servicio existente por su ID.
        /// </summary>
        /// <param name="id">ID del servicio a actualizar.</param>
        /// <param name="dto">Datos del servicio actualizado.</param>
        /// <returns>Una respuesta HTTP que indica el resultado de la operación.</returns>
        [Authorize(Policy = "Admin")]
        [HttpPut("Modificar/{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, AddProjectDto dto)
        {
            try
            {
                var updatedProject = new Project(dto, id);

                var result = await _unitOfWork.ProjectRepository.UpdateAsync(updatedProject);

                await _unitOfWork.Complete();

                if (result)
                {
                    return ResponseFactory.CreateSuccessResponse(201, "Modificado con éxito");
                }
                else
                {
                    return ResponseFactory.CreateErrorResponse(400, "No se pudo actualizar.");
                }
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, $"Error al actualizar: {ex.Message}");
            }

        }

        /// <summary>
        /// Realiza una eliminación lógica de un servicio por su ID.
        /// </summary>
        /// <param name="id">ID del servicio a eliminar.</param>
        /// <returns>Una respuesta HTTP que indica el resultado de la operación.</returns>
        [Authorize(Policy = "Admin")]
        [HttpPut("Eliminar/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var result = await _unitOfWork.ProjectRepository.DeleteAsync(id);
                await _unitOfWork.Complete();

                if (!result)
                {
                    return ResponseFactory.CreateErrorResponse(500, "No se pudo eliminar el proyecto");
                }
                else
                {
                    await _unitOfWork.Complete();
                    return ResponseFactory.CreateSuccessResponse(200, "Eliminado");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar: {ex.Message}");
            }
        }


    }
}
