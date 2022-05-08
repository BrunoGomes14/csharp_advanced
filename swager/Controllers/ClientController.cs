using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;



namespace swager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {

        [HttpGet("{id}")]
        public ActionResult<string> Consultar(int id)
        {
            return null;
        }

        [HttpGet]
        public ActionResult<string[]> Listar()
        {
            return null;
        }


        [HttpPost]
        public ActionResult Inserir(Models.Client client)
        {
            return null;
        }      
    }
}