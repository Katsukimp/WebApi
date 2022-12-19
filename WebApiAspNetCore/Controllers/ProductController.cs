using Microsoft.AspNetCore.Mvc;
using WebApiAspNetCore.Controllers.Shared;
using WebApiAspNetCore.Domain.Entities;
using WebApiAspNetCore.Domain.Interfaces.Services;
using WebApiAspNetCore.Domain.Validator;

namespace WebApiAspNetCore.Controllers
{
    public class ProductController : BaseController
    {
        /// <summary>
        /// Retorna um produto caso o mesmo exista 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id, [FromServices] IProductService service)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("O id informado é inválido.");
            }

            var result = await service.GetAsync(id);

            return result is not null ? Ok(result) : BadRequest($"Objeto com o id {id} não foi encontrado.");
        }

        /// <summary>
        /// Retorna todos os produtos
        /// </summary>
        /// <param name="category">Categorizador usado para consulta</param>
        /// <returns></returns>
        [HttpGet("{category?}")]
        public async Task<IActionResult> GetAllAsync([FromServices] IProductService service, [FromRoute] string category = "")
        {
            var result = service.GetAllAsync(new string[] { category });

            return result is not null ? await Task.FromResult(Ok(result)) : await Task.FromResult(BadRequest(result));
        }

        /// <summary>
        /// Adiciona produto caso sejá válido
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync(
            [FromBody] Product product,
            [FromServices] IProductService service,
            [FromServices] ProductValidator validator)
        {
            var model = await validator.ValidateAsync(product);
            if (model.IsValid)
            {
                await service.AddAsync(product);
                return Created("Created", product);
            }

            return BadRequest(model.Errors);
        }

        /// <summary>
        /// Atualiza o registro de um produto caso exista
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(
            [FromBody] Product product,
            [FromServices] IProductService service,
            [FromServices] ProductValidator validator)
        {
            var model = await validator.ValidateAsync(product);
            if (model.IsValid)
            {
                await service.UpdateAsync(product);
                return Created("Updated", product);
            }

            return BadRequest(model.Errors);
        }

        /// <summary>
        /// Remover o registro de produto caso seja encontrado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync([FromRoute] Guid id, [FromServices] IProductService service)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("O id enviado está vázio.");
            }

            await service.DeleteAsync(id);
            return Ok("Produto removido com sucesso.");
        }
    }
}
