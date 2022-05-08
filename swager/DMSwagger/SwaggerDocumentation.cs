using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Routing;
using swager.Models;

namespace swager.DMSwagger
{
    public class SwaggerDocumentation
    {
        private readonly List<DMSwaggerController> _controllers;

        public SwaggerDocumentation()
        {
            _controllers = new List<DMSwaggerController>();
        }

        public ReadOnlyCollection<DMSwaggerController> Controllers { get { return _controllers.AsReadOnly(); } }

        public SwaggerDocumentation WithController(Type controller)
        {
            var name = controller.Name.Replace("Controller", "");
            
            // Obter métodos decorados com HttpMethodAttributes
            var methods = controller
                .GetMethods()
                .Where(w => w.CustomAttributes.Any(a => a.AttributeType.BaseType.Equals(typeof(HttpMethodAttribute))))
                .ToList();

            // Obter etapas de documentação do Swagger
            DMSwaggerBase dmSwagger = GetSteps();

            // Percorrer métodos aplicando as etapas de documentação
            foreach (var methodInfo in methods)
            {
                var c = new DMSwaggerController();
                c.Name = name;
                
                dmSwagger.Execute(methodInfo, c);               

                _controllers.Add(c);
            }

            return this;
        }

        public Models.DMSwagger GetDMSwagger() => 
            new Models.DMSwagger() { Controllers = this.Controllers.ToList() };

        private DMSwaggerBase GetSteps()
        {
            var responseSwagger = new ResponseSwagger(null);
            var requestSwagger = new RequestSwagger(responseSwagger);
            var endPointStep = new EndPointSwagger(requestSwagger);

            return endPointStep;
        }
    }
}