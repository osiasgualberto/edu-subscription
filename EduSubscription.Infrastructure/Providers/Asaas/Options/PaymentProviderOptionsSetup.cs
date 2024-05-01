using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace EduSubscription.Infrastructure.Providers.Asaas.Options;

public class PaymentProviderOptionsSetup : IConfigureOptions<PaymentProviderOptions>
{
    private readonly IConfiguration _configuration;

    public PaymentProviderOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private const string AsaasPaymentGatewaySectionName = "Asaas";
    
    public void Configure(PaymentProviderOptions options)
    {
        _configuration.GetSection(AsaasPaymentGatewaySectionName).Bind(options);
    }
}