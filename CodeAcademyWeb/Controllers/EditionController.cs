using AcademyModel.Entities;
using AcademyModel.Exceptions;
using AcademyModel.Services;
using AutoMapper;
using CodeAcademyWeb.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAcademyWeb.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EditionController : Controller
	{
		private IEditionsService service;
        //private IDidactisService service;

        private IMapper mapper;
		public EditionController(IEditionsService service, IMapper mapper)
		{
			this.service = service;
			this.mapper = mapper;
		}
		[HttpGet]
		public IActionResult GetAll()
		{
			var editions = service.GetAllEditions();
			var editionDTOs = mapper.Map<IEnumerable<EditionDTO>>(editions);
			return Ok(editionDTOs);
		}
		[Route("{id}")]
		[HttpGet]
		public IActionResult FindById(long id)
		{
			var edition = service.GetEditionById(id);
			if (edition == null)
			{
				return NotFound();
			}
			var editionDTO = mapper.Map<EditionDetailsDTO>(edition);
			return Ok(editionDTO);
		}
		[HttpPost]
		public IActionResult Create(EditionDetailsDTO e)
		{
			try
			{
				var edition = mapper.Map<Edition>(e);
				service.CreateCourseEdition(edition);
				var courseEditionDTO = mapper.Map<EditionDetailsDTO>(edition);
				return Created($"/api/edition/{courseEditionDTO.Id}", courseEditionDTO);
			}
			catch (EntityNotFoundException ex)
			{
				return BadRequest(new ErrorObject(StatusCodes.Status400BadRequest, ex.Message));
			}
		}
		[HttpPut]
		public IActionResult Edit(EditionDetailsDTO e)
		{
			try
			{
				var edition = mapper.Map<Edition>(e);
				service.EditCourseEdition(edition);
				var courseEditionDTO = mapper.Map<EditionDetailsDTO>(edition);
				return Ok(courseEditionDTO);
			}
			catch (EntityNotFoundException ex)
			{
				switch (ex.EntityName)
				{
					case nameof(Edition):
						return NotFound(ex.Message);

					default:
						return BadRequest(new ErrorObject(StatusCodes.Status400BadRequest, ex.Message));
				}
			}
		}
		[Route("{id}")]
		[HttpDelete]
		public IActionResult Delete(long id)
		{
			try
			{
				service.DeleteCourseEdition(id);
				return NoContent();
			}
			catch (EntityNotFoundException ex)
			{
				return NotFound(new ErrorObject(StatusCodes.Status404NotFound, ex.Message));
			}
		}
		[HttpGet]
		[Route("course/{id}")]
		public IActionResult GetEditionsByCourseId(long id)
		{
			var editions = service.GetEditionsByCourseId(id);
			var editionDTOs = mapper.Map<IEnumerable<EditionDetailsDTO>>(editions);
			return Ok(editionDTOs);
		}
        [HttpGet]
        [Route("studentAvailable/{id}")]
        public IActionResult GetAvailableEnrollmentByStudentId(long id)
        {
            var enrollments = service.GetAvailableEnrollmentByStudentId(id);
            var enrollmentDTOs = mapper.Map<IEnumerable<EditionDetailsDTO>>(enrollments);
            return Ok(enrollmentDTOs);
        }
    }
}
