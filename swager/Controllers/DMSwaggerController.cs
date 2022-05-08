<<<<<<< HEAD
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using swager.DMSwagger;
=======
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Logging;
using swager.Models;
>>>>>>> ff021a33b9573ce8705b49b95c32de51016beb25

namespace swager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DMSwaggerReaderController : ControllerBase
    {
<<<<<<< HEAD
        [HttpGet]
        public ActionResult<Models.DMSwagger> Consultar()
        {
            var documentation = new SwaggerDocumentation()
                .WithController(typeof(ProductController))
                .WithController(typeof(ClientController));
=======

        [HttpGet("ProductController")]
        public ActionResult<DMSwaggerController> Consultar()
        {
            try
            {
                Type product = typeof(ProductController);
                return Read(product);     
            }
            catch (System.Exception e)
            {
                return Problem(e.ToString());
            }
        }


        DMSwaggerController Read(Type type)
        {
            DMSwaggerController dmController = new DMSwaggerController();
            dmController.Name = $"/{type.Name.Replace("Controller", string.Empty)}";

            foreach (var method in type.GetMethods())
            {
                
                var attribute = method.GetCustomAttribute<HttpMethodAttribute>();
                if (attribute == null)
                    continue;


                DMSwaggerEndpoint endpoint = new DMSwaggerEndpoint();
                endpoint.Path = $"/{attribute.Template}";
                endpoint.Verb = attribute.HttpMethods.First();


                foreach (var parameter in method.GetParameters())
                {
                    if (!parameter.ParameterType.IsPrimitive)
                    {
                        // body
                        foreach (var field in parameter.ParameterType.GetProperties())
                        {
                            endpoint.Request.Body.Fields.Add(
                                new DMSwaggerObject()
                                {
                                    Field = field.Name,
                                    Type = field.PropertyType.Name
                                });    
                        } 
                    }
                    else 
                    {
                        if (attribute.Template.Contains($"{{{parameter.Name}}}"))
                        {
                            // rota
                            endpoint.Request.Params.Add(
                                new DMSwaggerObject()
                                {
                                    Field = parameter.Name,
                                    Type = parameter.ParameterType.Name
                                });
                        }
                        else 
                        {
                            // query
                            endpoint.Request.Query.Add(
                                new DMSwaggerObject()
                                {
                                    Field = parameter.Name,
                                    Type = parameter.ParameterType.Name
                                });
                        }
                    }
                }





                if (method.ReturnType.IsGenericType)
                {
                    if (method.ReturnType.GenericTypeArguments.First().IsPrimitive)
                    {
                        endpoint.Response.Fields.Add(
                            new DMSwaggerObject()
                            {
                                Field = "primitive",
                                Type = method.ReturnType.GenericTypeArguments.First().Name
                            });
                    }
                    else
                    {
                        foreach (var field in method.ReturnType.GenericTypeArguments.First().GetProperties())
                        {
                            endpoint.Response.Fields.Add(
                                new DMSwaggerObject()
                                {
                                    Field = field.Name,
                                    Type = field.PropertyType.Name
                                });
                        }
                    }
                }
                else 
                {
                    if (method.ReturnType.Name.Contains("ActionResult"))
                    {
                        endpoint.Response.Fields.Add(
                            new DMSwaggerObject()
                            {
                                Field = "object",
                                Type = "object"
                            });
                    }
                    else 
                    {
                        foreach (var field in method.ReturnType.GetProperties())
                        {
                            endpoint.Response.Fields.Add(
                                new DMSwaggerObject()
                                {
                                    Field = field.Name,
                                    Type = field.PropertyType.Name
                                });
                        }
                    }
                }





                if (endpoint.Request.Body.Fields.Count == 0)
                    endpoint.Request.Body = null;
                if (endpoint.Request.Params.Count == 0)
                    endpoint.Request.Params = null;
                if (endpoint.Request.Query.Count == 0)
                    endpoint.Request.Query = null;

                dmController.Endpoints.Add(endpoint);
            }
            return dmController;
        }


















        
>>>>>>> ff021a33b9573ce8705b49b95c32de51016beb25

            return Ok(documentation.GetDMSwagger());
        }
    }
}