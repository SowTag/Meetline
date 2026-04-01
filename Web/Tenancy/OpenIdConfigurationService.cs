using System.Collections.Concurrent;
using Application.InternalServices;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

namespace Web.Tenancy;

public class OpenIdConfigurationService(ITenantReadService readService)
{
    private readonly ConcurrentDictionary<string, Guid> _issuerToId = new();
    private readonly ConcurrentDictionary<string, IConfigurationManager<OpenIdConnectConfiguration>> _managers = new();

    internal Guid? GetTenantId(string issuer)
    {
        if (_issuerToId.TryGetValue(issuer, out var cachedId)) return cachedId;

        var dbId = readService.GetTenantIdFromIssuerAsync(issuer).GetAwaiter().GetResult();

        if (dbId.HasValue) _issuerToId.TryAdd(issuer, dbId.Value);

        return dbId;
    }

    public IEnumerable<SecurityKey> GetKeys(string issuer)
    {
        var tenantId = GetTenantId(issuer);

        if (tenantId is null) return [];

        var manager = _managers.GetOrAdd(issuer, key =>
        {
            var discoveryUrl = key.TrimEnd('/') + "/.well-known/openid-configuration";

            return new ConfigurationManager<OpenIdConnectConfiguration>(
                discoveryUrl,
                new OpenIdConnectConfigurationRetriever(),
                new HttpDocumentRetriever());
        });

        var config = manager.GetConfigurationAsync(CancellationToken.None).GetAwaiter().GetResult();
        return config.SigningKeys;
    }
}