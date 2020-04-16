namespace CompanyManager.Web.ExceptionHandling.Builders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using CompanyManager.Web.ExceptionHandling.Entities;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Http;

    internal class ExceptionHandlerBuilder
    { 
        private IList<MemoryCell> _memoryBoxes;

        internal ExceptionHandlerBuilder(Action<ExceptionHandlerBuilder> setupActions)
        {
            _memoryBoxes = new List<MemoryCell>();
            setupActions(this);
        }

        public void WithException<T>(HttpStatusCode statusCode)
            where T : Exception
        {
            _memoryBoxes.Add(new MemoryCell
            {
                Type = typeof(T),
                ProductionMethod = ex => statusCode,
            });
        }

        public void WithException<T>(Func<T, HttpStatusCode> func)
            where T : Exception
        {
            _memoryBoxes.Add(new MemoryCell
            {
                Type = typeof(T),
                ProductionMethod = ex => func((T)ex),
            });
        }

        internal Func<Exception, HttpStatusCode> this[Type type]
        {
            get
            {
                var result = _memoryBoxes
                    .Where(el => type.IsSubclassOf(el.Type) || type == el.Type)
                    .FirstOrDefault();

                return result.Equals(default(KeyValuePair<Type, Func<Exception, HttpStatusCode>>))
                    ? ex => HttpStatusCode.InternalServerError
                    : result.ProductionMethod;
            }
        }

        public RequestDelegate BuildRequestDelegate()
        {
            return async context =>
            {
                var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (exceptionFeature != null)
                {
                    context.Response.StatusCode = (int)this[exceptionFeature.Error.GetType()](exceptionFeature.Error);
                }
            };
        }
    }
}
