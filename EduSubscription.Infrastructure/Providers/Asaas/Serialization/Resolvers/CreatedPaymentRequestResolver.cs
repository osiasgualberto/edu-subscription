using Newtonsoft.Json.Serialization;

namespace EduSubscription.Infrastructure.Providers.Asaas.Serialization.Resolvers;

public class CreatedPaymentRequestResolver : DefaultContractResolver
{
    private Dictionary<string, string?> _mappings;
    
    public CreatedPaymentRequestResolver()
    {
        _mappings = new()
        {
            { "Id", "id" },
        };
    }    
    protected override string ResolvePropertyName(string propertyName)
    {
        _mappings.TryGetValue(propertyName, out string? propertyValue);
        return propertyValue ?? base.ResolvePropertyName(propertyName);
    }
}