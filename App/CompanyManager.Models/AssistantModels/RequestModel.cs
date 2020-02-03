using CompanyManager.Models.AssistantModels.Results;

namespace CompanyManager.Models.AssistantModels
{
    public class RequestModel
    {
        public Enterprise Enterprise { get; set; }

        public UserPreferences UserPreferences { get; set; }

        public RequestResult RequestResult { get; set; }
    }
}
