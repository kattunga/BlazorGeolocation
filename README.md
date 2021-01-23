![build Actions Status](https://github.com/kattunga/BlazorGeolocation/workflows/build/badge.svg)

[![Nuget](https://img.shields.io/nuget/v/BlazorGeolocation?style=flat-square)](https://www.nuget.org/packages/BlazorGeolocation/)

# BlazorGeolocation
Geolocation component for Blazor using JSInterop

## Prerequisites

NET 5.0 or above

## Installation

### 1. NuGet packages

```
Install-Package BlazorGeolocation
```

or

```
dotnet add package BlazorGeolocation
```

### 2. add scoped service BlazorGeolocationService

For blazor wasm, in startup.cs
```
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<BlazorGeolocationService>();

            await builder.Build().RunAsync();
        }
    }
```

For blazor server, in program.cs
```
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();

            services.AddScoped<BlazorGeolocationService>();
        }
```

## Example


```html
@page "/"

@using BlazorGeolocation
@inject BlazorGeolocationService blazorGeolocationService

<button @onclick="TriggerGeoLocation">Get location</button>

<div>latitude: @position.latitude</div>
<div>longitude: @position.longitude</div>

@code {
    private BlazorGeolocationPosition position;

    public async Task TriggerGeoLocation()
    {
        position = await blazorGeolocationService.GetPositionAsync();;
    }
}
```
