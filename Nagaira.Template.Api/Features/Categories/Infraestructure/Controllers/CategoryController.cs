using Microsoft.AspNetCore.Mvc;
using Nagaira.Core.Extentions.Responses;
using Nagaira.Template.Api.Features.Categories.Application.Dtos;
using Nagaira.Template.Api.Features.Categories.Application.Services.Interfaces;

namespace Nagaira.Template.Api.Features.Categories.Infraestructure.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        [HttpGet, Route("")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _categoryAppService.GetAll();
            if (response.Type != TypeResponse.Ok) return BadRequest(response);

            return Ok(response);
        }

        [HttpPost, Route("")]
        public async Task<IActionResult> Post([FromBody] CategoryDto categoryDto)
        {
            var response = await _categoryAppService.Add(categoryDto);
            if (response.Type != TypeResponse.Ok) return BadRequest(response);

            return Ok(response);
        }

        [HttpPut, Route("")]
        public async Task<IActionResult> Put([FromBody] CategoryDto categoryDto)
        {
            var response = await _categoryAppService.Update(categoryDto);
            if (response.Type != TypeResponse.Ok) return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await _categoryAppService.Delete(id);
            if (response.Type != TypeResponse.Ok) return BadRequest(response);

            return Ok(response);
        }


    }
}
