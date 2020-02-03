using CompanyManager.Assistant.Entities.CountingModules;
using CompanyManager.Models;
using CompanyManager.Models.AssistantModels;
using CompanyManager.Models.AssistantModels.Results;
using System;
using System.Collections.Generic;

namespace CompanyManager.Assistant.Entities
{
    public class FinanceAssistant
    {
        private IEnumerable<ICountModule<RequestModel>> _countModules;

        public string Name { get; set; } = "Grisha";

        public FinanceAssistant(string name)
        {
            this.Name = name;
            AssistantSettings.InitializeModules(_countModules);
        }

        public FinanceAssistant(IEnumerable<ICountModule<RequestModel>> modules)
        {
            _countModules = modules ?? throw new ArgumentNullException(nameof(modules));
        }

        public RequestModel GetStatistics(Enterprise enterprise, UserPreferences userPreferences)
        {
            var model = new RequestModel
            {
                Enterprise = enterprise,
                UserPreferences = userPreferences,
                RequestResult = new RequestResult(),
            };

            foreach(var module in _countModules)
            {
                module.Calculate(model);
            }

            return model; 
        }
    }
}
