using System.Collections.Generic;
using System.Linq;
using apiwithpomelo.Entities;
using apiwithpomelo.Models;
using apiwithpomelo.Repositories;
using apiwithpomelo.Services;
using Microsoft.AspNetCore.Mvc;

namespace apiwithpomelo.Controllers
{
    [ApiController]
    [Route("v2/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClientesController(IClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            try
            {
                return _service.GetAll().ToList();            
            }
            catch (System.Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Cliente cliente) 
        {
            try
            {
                using (_service)
                {
                    return Created($"Cliente/{cliente.Id}", _service.Create(cliente));
                }
            }
            catch (System.Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] Cliente cliente) 
        {
            try
            {
                return Ok(_service.Update(cliente));
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
        public ActionResult<Cliente> Get(int id) 
        {
            try
            {
                return _service.Get(id);
            }
            catch (System.Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
