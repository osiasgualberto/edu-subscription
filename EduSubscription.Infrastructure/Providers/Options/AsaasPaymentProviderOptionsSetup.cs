using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace EduSubscription.Infrastructure.Providers.Options;

public class AsaasPaymentProviderOptionsSetup : IConfigureOptions<AsaasPaymentProviderOptions>
{
    private readonly IConfiguration _configuration;

    public AsaasPaymentProviderOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private const string AsaasPaymentGatewaySectionName = "Asaas";
    
    public void Configure(AsaasPaymentProviderOptions options)
    {
        _configuration.GetSection(AsaasPaymentGatewaySectionName).Bind(options);
    }
}