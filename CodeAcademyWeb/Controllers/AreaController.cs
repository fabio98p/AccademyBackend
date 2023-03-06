using AcademyModel.Services;
using AutoMapper;
using CodeAcademyWeb.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CodeAcademyWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : Controller
    {
        private IDidactisService service;
        private IMapper mapper;
        public AreaController(IDidactisService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("areas")]
        public IActionResult GetAllAreas()
        {
            var areas = service.GetAllAreas();
            var areaDTOs = mapper.Map<IEnumerable<AreaDTO>>(areas);
            return Ok(areaDTOs);
        }
    }
}
