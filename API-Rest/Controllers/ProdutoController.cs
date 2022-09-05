using API_Rest.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Rest.Services;
using API_Rest.Domain;
using System.Net.Http;

namespace API_Rest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        protected readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var produtos = await _produtoService.GetAll();
            return Ok(produtos);
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var produtos = await _produtoService.GetById(id);
            return Ok(produtos);
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByNome(string nome)
        {
            var produtos = await _produtoService.GetByNome(nome);
            return Ok(produtos);
        }

        // --

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult Insert([FromBody] Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _produtoService.Insert(produto);
            return CreatedAtAction(nameof(GetById), new { Id = produto.Id }, produto);
        }

        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Update([FromBody] Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _produtoService.Update(produto);
            return Ok();
        }

        [HttpDelete]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete(int id)
        {
            _produtoService.Delete(id);
            return Ok();
        }
    }
}
