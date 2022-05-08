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
    public class ProductController : ControllerBase
    {

        [HttpGet("{id}/Produto/Log/{name}")]
        public ActionResult<Models.Product> Consultar(int id
            , string name
            , decimal serie
            , [FromBody] Models.Product product)
        {
            return new Models.Product();
        }


        [HttpPost]
        public ActionResult<int> Inserir(Models.Product product)
        {
            return null;
        }      
    }
}

