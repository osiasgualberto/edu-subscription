using Newtonsoft.Json.Serialization;

namespace EduSubscription.Infrastructure.Providers.Asaas.Serialization;

public class PaymentContractResolver : DefaultContractResolver
{
    private Dictionary<string, string?> _mappings;
    
    public PaymentContractResolver()
    {
        _mappings = new()
        {
            { "CustomerDocument", "customer" },
            { "Value", "value" },
            { "Due", "dueDate" },
            { "Installments", "installmentsValue" },
        };
    }    
    protected override string ResolvePropertyName(string propertyName)
    {
        _mappings.TryGetValue(propertyName, out string? propertyValue);
        return propertyValue ?? base.ResolvePropertyName(propertyName);
    }
}