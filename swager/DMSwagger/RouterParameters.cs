using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using swager.Models;

namespace swager.DMSwagger
{
    public class RouterParameters
    {
        private readonly string _template;
        private readonly MethodInfo _methodInfo;

        public RouterParameters(string template, MethodInfo methodInfo)
        {
            _template = template;
            _methodInfo = methodInfo;
        }

        public string[] GetNames()
        {
            var parts = _template?.Split("/");
            
            return parts?
                .Where(w => w.StartsWith("{"))?
                .Select(s => s.Replace("{", "").Replace("}", ""))?
                .ToArray();
        }

        public void LoadParameters(DMSwaggerRequest dmRequest)
        {
            var parameterInfoRoutes = GetInfos();
            
            // Preencher parâmetros de rota
            if (parameterInfoRoutes != null && parameterInfoRoutes.Count() > 0)
            {
                dmRequest.Params = new List<DMSwaggerObject>(
                    parameterInfoRoutes.Select(s => new DMSwaggerObject()
                    {
                        Field = s.Name,
                        Type = s.ParameterType.FullName
                    })
                );
            }
        }

        private ParameterInfo[] GetInfos()
        {
            var parameters = _methodInfo.GetParameters();
            var routeParameters = GetNames();

            return parameters?
                .Where(w => routeParameters?.Any(a => a == w.Name) ?? false
                    && w.ParameterType.IsPrimitive)?
                .ToArray();
        }
    }
}