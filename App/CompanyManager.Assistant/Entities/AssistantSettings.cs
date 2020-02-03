using CompanyManager.Assistant.Entities.CountingModules;
using CompanyManager.Assistant.Entities.CountingModules.Realizations;
using CompanyManager.Models.AssistantModels;
using System.Collections.Generic;

namespace CompanyManager.Assistant.Entities
{
    internal class AssistantSettings
    {
        internal static void InitializeModules(IEnumerable<ICountModule<RequestModel>> modules)
        {
            modules = new List<ICountModule<RequestModel>>
            {
                new EmployeeModule(),
                new PurchaseModule(),
            };
        }
    }
}
