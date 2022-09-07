using API_Rest.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using API_Rest.Services;
using API_Rest.Domain;
using System.Net.Http;

namespace API_Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class ProdutoController : ControllerBase
    {
        protected readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var produtos = await _produtoService.GetAll();
            return Ok(produtos);
        }
               
        [HttpGet]
        [Route("[Action]")]       
        [ProducesResponseType(StatusCodes.Status200OK)]        
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var produtos = await _produtoService.GetById(id);
                return Ok(produtos);
            }
            catch (System.Exception)
            {

                throw;
            }          
        }
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]        
        [Route("[Action]")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            var produtos = await _produtoService.GetByNome(nome);
            return Ok(produtos);
        }
        // --
        [HttpPost]
        [ProducesDefaultResponseType]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
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

        /// <summary>
        /// Deleta produto específico.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[HttpDelete]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            _produtoService.Delete(id);
            return Ok();
        }
    }
}
