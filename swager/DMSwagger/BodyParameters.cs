using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using swager.Models;

namespace swager.DMSwagger
{
    public class BodyParameters
    {
        private readonly MethodInfo _methodInfo;

        public BodyParameters(MethodInfo methodInfo)
        {
            _methodInfo = methodInfo;
        }

        public void LoadBody(DMSwaggerRequest dmRequest)
        {
            var info = GetInfo();

            // Preencher body
            if (info != null)
            {
                dmRequest.Body = new DMSwaggerBody() { Fields = new List<DMSwaggerObject>() };
                
                var typeBody = Type.GetType(info.ParameterType.FullName);
                var properties = typeBody.GetProperties();

                dmRequest.Body.Fields.AddRange(
                    properties.Select(s => new DMSwaggerObject()
                    {
                        Field = s.Name,
                        Type = s.PropertyType.FullName
                    }).ToList()
                );
            }
        }

        private ParameterInfo GetInfo() =>
            _methodInfo?
                .GetParameters()
                .FirstOrDefault(f => f.ParameterType.AssemblyQualifiedName.StartsWith("swager"));//f.GetCustomAttributes<FromBodyAttribute>() != null);// 
    }
}