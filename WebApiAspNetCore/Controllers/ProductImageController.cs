using Microsoft.AspNetCore.Mvc;
using WebApiAspNetCore.Controllers.Shared;
using WebApiAspNetCore.Domain.Entities;
using WebApiAspNetCore.Domain.Interfaces.Services;
using WebApiAspNetCore.Domain.Validator;

namespace WebApiAspNetCore.Controllers
{
    public class ProductImageController : BaseController
    {

        /// <summary>
        /// Retorna a imagem do produto caso exista
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id, [FromServices] IProductImageService service)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("O id informado é inválido.");
            }

            var result = await service.GetAsync(id);

            return result is not null ? Ok(result) : BadRequest($"Nenhuma imagem com o id {id} foi encontrada.");
        }

        /// <summary>
        /// Retorna a lista de imagem de produtos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromServices] IProductImageService service)
        {
            var result = service.GetAllAsync(new string[] { "Product" });
            return result is not null ? await Task.FromResult(Ok(result)) : await Task.FromResult(BadRequest(result));
        }

        /// <summary>
        /// Adiciona imagem do produto
        /// </summary>
        /// <param name="productImage"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync(
            [FromBody] ProductImage productImage,
            [FromServices] IProductImageService service,
            [FromServices] ProductImageValidator validator)
        {
            var model = await validator.ValidateAsync(productImage);
            if (!model.IsValid)
            {
                return BadRequest(model.Errors);
            }

            await service.AddAsync(productImage);
            return Created("Created", productImage);
        }

        /// <summary>
        /// Atualiza imagem do produto caso exista
        /// </summary>
        /// <param name="productImage"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(
            [FromBody] ProductImage productImage,
            [FromServices] IProductImageService service,
            [FromServices] ProductImageValidator validator)
        {
            var model = await validator.ValidateAsync(productImage);
            if (model.IsValid)
            {
                await service.UpdateAsync(productImage);
                return Created("Updated", productImage);
            }

            return BadRequest(model.Errors);
        }

        /// <summary>
        /// Remove imagem do produto caso exista
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(
            [FromRoute] Guid id,
            [FromServices] IProductImageService service)
        {
            if (id != Guid.Empty)
            {
                await service.DeleteAsync(id);

                return Ok("Imagem do produto removido com sucesso.");
            }

            return BadRequest("Id inválido");
        }
    }
}
