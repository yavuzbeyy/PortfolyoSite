using Katmanli.DataAccess.DTOs;
using Katmanli.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Katmanli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutMeController : ControllerBase
    {
        private readonly IAboutMeService _aboutMeService;

        public AboutMeController(IAboutMeService aboutMeService)
        {
            _aboutMeService = aboutMeService;
        }

        [HttpGet("ListAll")]
        public IActionResult List()
        {
            var getAboutMe = _aboutMeService.List();
            return Ok(getAboutMe);
        }

        [HttpPost("Create")]
        public IActionResult Create(AboutMeCreate aboutMeCreateModel)
        {
            var createAboutMe = _aboutMeService.Create(aboutMeCreateModel);
            return Ok(createAboutMe);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var deleteAboutMe = _aboutMeService.Delete(id);
            return Ok(deleteAboutMe);
        }

        [HttpPut("Update")]
        public IActionResult Update(AboutMeUpdate aboutMeUpdateModel)
        {
            var updateAboutMe = _aboutMeService.Update(aboutMeUpdateModel);
            return Ok(updateAboutMe);
        }
    }
}
