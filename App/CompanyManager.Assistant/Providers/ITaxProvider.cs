namespace CompanyManager.Assistant.Providers
{
    internal interface ITaxProvider
    {
        decimal GetActualTax(string contry, string type); //need to rework
    }
}
