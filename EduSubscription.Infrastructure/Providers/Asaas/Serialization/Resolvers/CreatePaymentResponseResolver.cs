using Newtonsoft.Json.Serialization;

namespace EduSubscription.Infrastructure.Providers.Asaas.Serialization.Resolvers;

public class CreatePaymentResponseResolver : DefaultContractResolver
{
    private Dictionary<string, string?> _mappings;
    
    public CreatePaymentResponseResolver()
    {
        _mappings = new()
        {
            { "Customer", "customer" },
            { "Value", "value" },
            { "Due", "dueDate" },
            { "Installments", "installmentsValue" },
            { "ChargeType", "billingType"}
        };
    }    
    protected override string ResolvePropertyName(string propertyName)
    {
        _mappings.TryGetValue(propertyName, out string? propertyValue);
        return propertyValue ?? base.ResolvePropertyName(propertyName);
    }
}