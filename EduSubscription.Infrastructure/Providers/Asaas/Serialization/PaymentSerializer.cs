using EduSubscription.Application.Providers.Payment.Models;
using EduSubscription.Application.Providers.Payment.Models.Requests;
using EduSubscription.Application.Providers.Payment.Models.Responses;
using EduSubscription.Infrastructure.Providers.Asaas.Contracts;
using EduSubscription.Infrastructure.Providers.Asaas.Serialization.Resolvers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EduSubscription.Infrastructure.Providers.Asaas.Serialization;

public class PaymentSerializer : IPaymentSerializer
{
    private JsonSerializer _serializer = new();

    private Dictionary<string, DefaultContractResolver> _resolvers = new()
    {
        { typeof(CreatePaymentRequest).Name, new CreatePaymentResponseResolver() },
        { typeof(CreatedPaymentResponse).Name, new CreatedPaymentRequestResolver() }
    };

    public PaymentSerializer()
    {
        _serializer.NullValueHandling = NullValueHandling.Ignore;
    }

    public string Serialize<TPaymentModel>(TPaymentModel toBeSerialized) where TPaymentModel : PaymentModel
    {
        using var memString = new StringWriter();
        using var jsonWriter = new JsonTextWriter(memString);
        _resolvers.TryGetValue(toBeSerialized.GetType().Name, out var resolver);
        if (resolver is null) resolver = new DefaultContractResolver();
        _serializer.ContractResolver = resolver;
        _serializer.Serialize(jsonWriter, toBeSerialized);
        return memString.ToString();
    }

    public TPaymentModel? Deserialize<TPaymentModel>(string toBeDeserialized) where TPaymentModel : PaymentModel
    {
        using var memString = new StringReader(toBeDeserialized);
        using var jsonReader = new JsonTextReader(memString);
        _resolvers.TryGetValue(nameof(toBeDeserialized), out var resolver);
        if (resolver is null) resolver = new DefaultContractResolver();
        _serializer.ContractResolver = resolver;
        return _serializer.Deserialize<TPaymentModel>(jsonReader);
    }
}