using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using swager.Models;

namespace swager.DMSwagger
{
    public class ResponseSwagger : DMSwaggerBase
    {
        public ResponseSwagger(DMSwaggerBase next) : base(next)
        {
            
        }

        public override void Execute(MethodInfo info, DMSwaggerController controllerSW)
        {
            if (info.ReturnType != null)
            {
                var routeTemplate = info
                    .GetCustomAttributes<HttpMethodAttribute>()
                    .FirstOrDefault()
                    .Template;

                if (controllerSW.Endpoints.Last().Response == null)
                    controllerSW.Endpoints.Last().Response = new DMSwaggerResponse();

                var dmResponse = controllerSW.Endpoints.Last().Response;

                var properties = info.ReturnType.IsGenericType 
                    ? info.ReturnType.GenericTypeArguments.FirstOrDefault().GetProperties()
                    : info.ReturnType.GetProperties();

                if (dmResponse.Fields == null)
                    dmResponse.Fields = new List<DMSwaggerObject>();

                dmResponse.Fields.AddRange(
                    properties
                        .Select(s => new DMSwaggerObject()
                        {
                            Field = s.Name,
                            Type = s.PropertyType.FullName
                        })
                        .ToList()
                );
            }

            _next?.Execute(info, controllerSW);            
        }
    }
}