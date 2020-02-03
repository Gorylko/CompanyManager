using CompanyManager.Models.AssistantModels;

namespace CompanyManager.Assistant.Entities.CountingModules
{
    public interface ICountModule<TModel>
    {
        void Calculate(TModel requestModel);
    }
}
