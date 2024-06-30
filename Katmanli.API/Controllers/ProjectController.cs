using Katmanli.DataAccess.DTOs;
using Katmanli.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Katmanli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(ProjectCreate model)
        {
            var response = _projectService.Create(model);
            if (response.Success)
            {
                return Ok(response.Message);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var response = _projectService.Delete(id);
            if (response.Success)
            {
                return Ok(response.Message);
            }
            return NotFound(response.Message);
        }


        [HttpGet]
        [Route("ListAll")]
        public IActionResult ListAll()
        {
            var response = _projectService.ListAll();
            if (response.Success)
            {
                return Ok(response.Data);
            }
            return NotFound(response.Message);
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(ProjectUpdate model)
        {
            var response = _projectService.Update(model);
            if (response.Success)
            {
                return Ok(response.Message);
            }
            return NotFound(response.Message);
        }
    }
}
