namespace CompanyManager.Web.ExceptionHandling.Entities
{
    using System;
    using System.Net;

    public class MemoryCell
    {
        public Type Type { get; set; }

        public Func<Exception, HttpStatusCode> ProductionMethod { get; set; }
    }
}
