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
	public class EnrollmentController : Controller
	{
		private IPeopleService service;
		private IMapper mapper;
		public EnrollmentController(IPeopleService service, IMapper mapper)
		{
			this.service = service;
			this.mapper = mapper;
		}
		[HttpGet]
		[Route("studentSubscribed/{id}")]
		public IActionResult GetEnrollmentByStudentId(long id)
		{
			var enrollments = service.GetSubscribedEnrollmentByStudentId(id);
			var enrollmentDTOs = mapper.Map<IEnumerable<EnrollmentDTO>>(enrollments);
			return Ok(enrollmentDTOs);
		}
        [HttpGet]
        [Route("studentAvailable/{id}")]
        public IActionResult GetAvailableEnrollmentByStudentId(long id)
        {
            var enrollments = service.GetAvailableEnrollmentByStudentId(id);
            var enrollmentDTOs = mapper.Map<IEnumerable<CourseEditionDetailsDTO>>(enrollments);
            return Ok(enrollmentDTOs);
        }
		[HttpPost]
		public IActionResult Create(EnrollmentDTO e)
		{
			try
			{
				var enrollment = mapper.Map<Enrollment>(e);
				service.CreateEnrollment(enrollment);
				var enrollmentDTO = mapper.Map<EnrollmentDTO>(enrollment);
				return Created($"/api/edition/{enrollmentDTO.Id}", enrollmentDTO);
			}
			catch (EntityNotFoundException ex)
			{
				return BadRequest(new ErrorObject(StatusCodes.Status400BadRequest, ex.Message));
			}
		}
		[HttpDelete]
		[Route("{id}")]
		public IActionResult DeleteEnroll(long id)
		{
			service.DeleteEnrollment(id);
			return Ok();
		}
	}
	
}
