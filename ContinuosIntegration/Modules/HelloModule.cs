using Microsoft.AspNetCore.Mvc;

namespace ContinuosIntegration.Modules;

public static class HelloModule
{
    public static IEndpointRouteBuilder MapHelloEndpoint(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("v1/hello", ([FromQuery] string name) =>
            {
                return $"Hello From CD/CI {name}";
            })
            .WithName("Hello");

        return endpoints;
    }
}