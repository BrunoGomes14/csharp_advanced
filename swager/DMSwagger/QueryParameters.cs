using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using swager.Models;

namespace swager.DMSwagger
{
    public class QueryParameters
    {
        private readonly string[] _routerNames;
        private readonly MethodInfo _methodInfo;

        public QueryParameters(string[] routerNames, MethodInfo methodInfo)
        {
            _routerNames = routerNames;
            _methodInfo = methodInfo;
        }

        public void LoadParameters(DMSwaggerRequest dmRequest)
        {
            var parameterInfoRoutes = GetInfos();
            
            // Preencher parâmetros de rota
            if (parameterInfoRoutes != null && parameterInfoRoutes.Count() > 0)
            {
                dmRequest.Query = new List<DMSwaggerObject>(
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

            return parameters?
                .Where(w => _routerNames?.All(a => a != w.Name) ?? true
                    && w.ParameterType.IsPrimitive)?
                .ToArray();
        }
    }
}