using Katmanli.DataAccess.DTOs;
using Katmanli.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Katmanli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(ArticleCreate model)
        {
            var response = _articleService.Create(model);
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
            var response = _articleService.Delete(id);
            if (response.Success)
            {
                return Ok(response.Message);
            }
            return NotFound(response.Message);
        }

        [HttpGet]
        [Route("GetByArticleName/{articleName}")]
        public IActionResult GetByArticleName(string articleName)
        {
            var response = _articleService.GetArticleByArticleName(articleName);
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
            var response = _articleService.ListAll();
            if (response.Success)
            {
                return Ok(response.Data);
            }
            return NotFound(response.Message);
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(ArticleUpdate model)
        {
            var response = _articleService.Update(model);
            if (response.Success)
            {
                return Ok(response.Message);
            }
            return NotFound(response.Message);
        }
    }
}
