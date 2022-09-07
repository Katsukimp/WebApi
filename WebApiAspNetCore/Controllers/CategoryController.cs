using Microsoft.AspNetCore.Mvc;
using WebApiAspNetCore.Controllers.Shared;
using WebApiAspNetCore.Domain.Entities;
using WebApiAspNetCore.Domain.Interfaces.Services;
using WebApiAspNetCore.Domain.Validator;

namespace WebApiAspNetCore.Controllers
{
    public class CategoryController : BaseController
    {
        /// <summary>
        /// Retorna categoria caso exista
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(
            [FromRoute] Guid id,
            [FromServices] ICategoryService service)
        {
            if (id != Guid.Empty)
            {
                var content = await service.GetAsync(id);
                return content is not null ? Ok(content) : BadRequest($"Objeto com o id {id} não foi encontrado.");
            }

            return BadRequest("Id informado é inválido.");
        }

        /// <summary>
        /// Retorna todas as categorias
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(
            [FromServices] ICategoryService service)
        {
            var contents = service.GetAllAsync();
            return contents is not null ? await Task.FromResult(Ok(contents)) : await Task.FromResult(BadRequest(contents));
        }


        /// <summary>
        /// Adiciona uma categoria caso seja válida.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync(
            [FromBody] Category category,
            [FromServices] ICategoryService service,
            [FromServices] CategoryValidator validator)
        {
            var model = await validator.ValidateAsync(category);
            if (model.IsValid)
            {
                await service.AddAsync(category);
                return Created("Created", category);
            }

            return BadRequest(model.Errors);
        }

        /// <summary>
        /// Atualiza registro de categoria caso seja válido e encontrado.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(
            [FromBody] Category category,
            [FromServices] ICategoryService service,
            [FromServices] CategoryValidator validator)
        {
            var model = await validator.ValidateAsync(category);
            if (model.IsValid)
            {
                await service.UpdateAsync(category);
                return Created("Updated", category);
            }

            return BadRequest(model.Errors);
        }


        /// <summary>
        /// Remove registro de categoria caso seja válido e encontrado.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(
            [FromRoute] Guid id,
            [FromServices] ICategoryService service)
        {
            if (id !=  Guid.Empty)
            {
                await service.DeleteAsync(id);
                return Ok("Categoria removida com sucesso.");
            }

            return BadRequest("Id inválido.");
        }

    }
}
