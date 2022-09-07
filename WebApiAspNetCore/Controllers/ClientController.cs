using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using WebApiAspNetCore.Controllers.Shared;
using WebApiAspNetCore.Domain.Entities;
using WebApiAspNetCore.Domain.Interfaces.Services;
using WebApiAspNetCore.Domain.Validator;

namespace WebApiAspNetCore.Controllers
{
    public class ClientController : BaseController
    {
        /// <summary>
        /// Retorna cliente caso exista
        /// </summary>
        /// <param name="Id">Código para consulta</param>
        /// <returns>Retorna um cliente caso o id informado sejá válido.</returns>
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAsync(
            [FromRoute] Guid Id, 
            [FromServices] IClientService service)
        {
            if (Id != Guid.Empty)
            {
                var content = await service.GetAsync(Id);
                return content is null ? Ok(content) : BadRequest($"Objeto com o id {Id} não foi encontrado.");
            }

            return BadRequest("Id informado é inválido.");
        }

        /// <summary>
        /// Adiciona um cliente caso seja válido.
        /// </summary>
        /// <param name="client">Cliente há ser inserido</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync(
            [FromBody] Client client, 
            [FromServices] IClientService service,
            [FromServices] ClientValidator validator)
        {
            var model = await validator.ValidateAsync(client);
            if (model.IsValid)
            {
                await service.AddAsync(client);
                return Created("Created", client);
            }

            return BadRequest(model.Errors);
        }

        /// <summary>
        /// Retorna todos os registros de clientes encontrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromServices] IClientService service)
        {
            var result = service.GetAllAsync();
            return result is null ? await Task.FromResult(BadRequest(result)) : await Task.FromResult(Ok(result));
        }

        /// <summary>
        /// Atualiza o registro de um cliente caso seja encontrado.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(
            [FromBody] Client client,
            [FromServices] IClientService service,
            [FromServices] ClientValidator validator)
        {
            var model = await validator.ValidateAsync(client);
            if (model.IsValid)
            {
                await service.UpdateAsync(client);
                return Created("Updated", client);
            }

            return BadRequest(model.Errors);
        }


        /// <summary>
        /// Remove o registro do cliente caso seja encontrado.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(
            [FromRoute] Guid id,
            [FromServices] IClientService service)
        {
            if (id != Guid.Empty)
            {
                await service.DeleteAsync(id);

                return Ok("Cliente removido com sucesso.");
            }

            return BadRequest("Id inválido");
        }
    }
}
