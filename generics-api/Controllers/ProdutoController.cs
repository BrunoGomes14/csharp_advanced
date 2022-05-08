using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace generics_api.Models
{

    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {

        // Models.mysql_17753_devmonkContext db;
        // public ProdutoController()
        // {
        //     db = new mysql_17753_devmonkContext();
        // }


        // [HttpGet]
        // public ActionResult<List<Models.TbProduto>> List()
        // {
        //     return db.TbProdutos.ToList();
        // }

        static int numero = 0;


        [HttpGet("Alterar/{id}")]
        public ActionResult Alterar(int id)
        {
            if (id == 0)
                return Ok(numero);
            
            numero = id;
            return Ok(numero);
        }


        [HttpGet("ListarNonBlocking/{id}")]
        public async Task<ActionResult> ListarNonBlocking(int id)
        {
            if (id == 1)
            {
                System.Threading.Thread.Sleep(20000);
            }
            return Ok(id);
        }


        [HttpGet("ListarBlocking/{id}")]
        public ActionResult ListarBlocking(int id)
        {
            if (id == 1)
            {
                System.Threading.Thread.Sleep(20000);
            }
            return Ok(id);
        }



        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            return StatusCode(1, new { mensagem = "regra de negócio zuou"});
            //return Ok(new List<int>() { 1, 2, 3 });
            //return Ok(10);
            //return new List<int>();
        }


        [HttpGet("Listar3")]
        public ActionResult Listar3()
        {
            return Ok(new List<int>() { 1, 2, 3 });
            //return new List<int>();
        }


        [HttpGet("Listar4")]
        public ActionResult<List<int>> Listar4()
        {
            //return Conflict("Ocorreu um problema!");
            try
            {
                return new List<int>();
            }
            catch (System.Exception ex)
            {
                return Problem(ex.Message);
            }
        }


        [HttpGet("Listar2")]
        public List<int> Listar2()
        {
            try
            {
                int x = 0;
                int a = 10 / x;
                return new List<int>() { 1, 2, 3 };     
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            //return new List<int>();
        }



    }

}