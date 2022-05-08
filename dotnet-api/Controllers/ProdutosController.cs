using System.Collections.Generic;
using apiwithpomelo.Models;
using apiwithpomelo.Services;
using Microsoft.AspNetCore.Mvc;

namespace apiwithpomelo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _service;

        public ProdutosController(IProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch (System.Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Produto produto) 
        {
            try
            {
                return Created($"Produto/{produto.Id}", _service.Create(produto));
            }
            catch (System.Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] Produto produto) 
        {
            try
            {
                return Ok(_service.Update(produto));
            }
            catch (System.Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            try
            {
                _service.Delete(id);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        {
            try
            {
                var produto = _service.Get(id);
                return Ok(produto);
            }
            catch (System.Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
