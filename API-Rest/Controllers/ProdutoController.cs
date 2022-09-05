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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProduto()
        {
            var produtos = await _produtoService.GetAllProduto();

            return Ok(produtos);
        }

        //[HttpGet("{Id}")]
        [Route("{action}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProdutoById(int id)
        {
            var produtos = await _produtoService.GetProdutoById(id);
            return Ok(produtos);
        }

        //[HttpGet("{Nome}")]
        [Route("{action}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProdutoByNome(string nome)
        {
            var produtos = await _produtoService.GetProdutoByNome(nome);
            return Ok(produtos);
        }

        // --

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddProdutos([FromBody] Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _produtoService.AddProdutos(produto);
            return CreatedAtAction(nameof(GetProdutoById), new { Id = produto.Id }, produto);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateProduto([FromBody] Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _produtoService.UpdateProduto(produto);
            return Ok();
        }

        [HttpDelete]        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteProduto(int id)
        {
             _produtoService.DeleteProduto(id);
            return Ok();
        }
    }
}
