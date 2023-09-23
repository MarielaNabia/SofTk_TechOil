﻿using Microsoft.AspNetCore.Authorization;
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
    public class ServiceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServiceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Obtiene una lista paginada de todos los servicios.
        /// </summary>
        /// <returns>Una respuesta HTTP que contiene la lista de servicios paginada.</returns>
        [HttpGet]
        [Route("Service")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var servicios = await _unitOfWork.ServiceRepository.GetAllAsync();
            int pageToShow = 1;

            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);

            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            var paginateServicios = PaginateHelper.Paginate(servicios, pageToShow, url);

            return ResponseFactory.CreateSuccessResponse(200, paginateServicios);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, $"Error al obtener la lista de servicios: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtiene una lista de servicios activos.
        /// </summary>
        /// <returns>Una respuesta HTTP que contiene la lista de servicios activos.</returns>

        [HttpGet]
        [Route("ServiceActive")]
        public async Task<IActionResult> GetActiveServices()
        {
            try
            {
                var servicios = await _unitOfWork.ServiceRepository.GetActiveServicesAsync();

                return ResponseFactory.CreateSuccessResponse(200, servicios);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, $"Error al obtener la lista de servicios activos: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtiene un servicio por su ID.
        /// </summary>
        /// <param name="id">ID del servicio a obtener.</param>
        /// <returns>Una respuesta HTTP que contiene el servicio encontrado o un mensaje de not found.</returns>

        [HttpGet("ServiceById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var servicio = await _unitOfWork.ServiceRepository.GetByIdAsync(id);

                if (servicio == null)
                {
                    return NotFound();
                }

                return ResponseFactory.CreateSuccessResponse(200, servicio);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, $"Error al obtener el servicio por ID: {ex.Message}");
            }
        }

        /// <summary>
        /// Crea un nuevo servicio.
        /// </summary>
        /// <param name="dto">Datos del nuevo servicio.</param>
        /// <returns>Una respuesta HTTP que indica el resultado de la operación.</returns>

        //[Authorize(Policy = "Admin")]
        [HttpPost]
        [Route("NewService")]
        public async Task<IActionResult> NewService(AddServiceDto dto)
        {
            try
            {
                var service = new Service(dto);
                await _unitOfWork.ServiceRepository.CreateAsync(service);
                await _unitOfWork.Complete();

                return ResponseFactory.CreateSuccessResponse(201, "Servicio creado con éxito");
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, $"Error al crear el servicio: {ex.Message}");
            }
        }

        /// <summary>
        /// Actualiza un servicio existente por su ID.
        /// </summary>
        /// <param name="id">ID del servicio a actualizar.</param>
        /// <param name="dto">Datos del servicio actualizado.</param>
        /// <returns>Una respuesta HTTP que indica el resultado de la operación.</returns>
        //[Authorize(Policy = "Admin")]
        [HttpPut("Editar/{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, AddServiceDto dto)
        {
            try
            {
                var updatedService = new Service(dto, id);

                var result = await _unitOfWork.ServiceRepository.UpdateAsync(updatedService);

                await _unitOfWork.Complete();

                if (result)
                {
                    return Ok(true);
                }
                else
                {
                    return ResponseFactory.CreateErrorResponse(400, "No se pudo actualizar el servicio.");
                }
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, $"Error al actualizar el servicio: {ex.Message}");
            }

        }

        /// <summary>
        /// Realiza una eliminación lógica de un servicio por su ID.
        /// </summary>
        /// <param name="id">ID del servicio a eliminar.</param>
        /// <returns>Una respuesta HTTP que indica el resultado de la operación.</returns>
        [Authorize(Policy = "Admin")]
        [HttpPut("DeleteLogico/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var result = await _unitOfWork.ServiceRepository.DeleteAsync(id);
                await _unitOfWork.Complete();

                if (result)
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest("No se pudo eliminar el servicio.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el servicio: {ex.Message}");
            }
        }


    }
}