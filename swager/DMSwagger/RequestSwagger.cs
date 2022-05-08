using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Routing;
using swager.Models;

namespace swager.DMSwagger
{
    public class RequestSwagger : DMSwaggerBase
    {
        public RequestSwagger(DMSwaggerBase next) : base(next)
        {
            
        }

        public override void Execute(MethodInfo methodInfo, DMSwaggerController controllerSW)
        {
            var routeTemplate = methodInfo
                .GetCustomAttributes<HttpMethodAttribute>()
                .FirstOrDefault()
                .Template;
              
            var dmRequest = new DMSwaggerRequest();

            var routerParameters = new RouterParameters(routeTemplate, methodInfo);      
            routerParameters.LoadParameters(dmRequest);

            new QueryParameters(routerParameters.GetNames(), methodInfo)
                .LoadParameters(dmRequest);

            new BodyParameters(methodInfo)
                .LoadBody(dmRequest);

            controllerSW.Endpoints.Last().Request = dmRequest;
            _next?.Execute(methodInfo, controllerSW);            
        }
    }
}