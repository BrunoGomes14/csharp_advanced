using System.Reflection;
using swager.Models;

namespace swager.DMSwagger
{
    public abstract class DMSwaggerBase
    {
        protected readonly DMSwaggerBase _next;

        public DMSwaggerBase(DMSwaggerBase next = null)
        {
            _next = next;
        }

        public abstract void Execute(MethodInfo info, DMSwaggerController controllerSW);
    }
}