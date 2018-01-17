<h1 align="center">ICE³X API</h1>

<h4 align="center">.NET client for <a href="https://www.ice3x.com/">ICE³X.com bitcoin exchange API</a></h4>
<p align="center">
    <a href="https://www.nuget.org/packages/ice3x-api">
        <img src="https://img.shields.io/nuget/v/ice3x-api.svg" alt="NuGet Package">
    </a>
</p>

## Getting Started

```csharp
using ice3x_api;
```

```csharp
var client = new Ice3XClient(_privateKey, _publicKey);

var response = await client.GetMarketDepthFullAsync();
foreach (var getMarketDepthFullEntity in response.Response.Entities)
{
    Console.WriteLine(getMarketDepthFullEntity.LastPrice);
}
```
