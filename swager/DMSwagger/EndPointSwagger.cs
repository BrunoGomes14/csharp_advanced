using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Routing;
using swager.Models;

namespace swager.DMSwagger
{
    public class EndPointSwagger : DMSwaggerBase
    {
        public EndPointSwagger(DMSwaggerBase next) : base(next)
        {
            
        }

        public override void Execute(MethodInfo info, DMSwaggerController controllerSW)
        {
            var attribute = info.GetCustomAttributes<HttpMethodAttribute>().FirstOrDefault();

            if (attribute != null)
            {
                string pathTemplate = string.IsNullOrEmpty(attribute.Template)
                    ? string.Empty
                    : $"/{attribute.Template}";

                if (controllerSW.Endpoints == null) 
                    controllerSW.Endpoints = new List<DMSwaggerEndpoint>();

                controllerSW.Endpoints.Add(new DMSwaggerEndpoint()
                {
                    Verb = attribute.HttpMethods.FirstOrDefault(),
                    Path = $"/{controllerSW.Name}{pathTemplate}"
                });
            }
                
            _next?.Execute(info, controllerSW);            
        } 
    }
}