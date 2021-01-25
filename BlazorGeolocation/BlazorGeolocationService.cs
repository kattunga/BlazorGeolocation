using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace BlazorGeolocation
{
    // This class provides an example of how JavaScript functionality can be wrapped
    // in a .NET class for easy consumption. The associated JavaScript module is
    // loaded on demand when first needed.
    //
    // This class can be registered as scoped DI service and then injected into Blazor
    // components for use.

    public class BlazorGeolocationService : IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public BlazorGeolocationService(IJSRuntime jsRuntime)
        {
            moduleTask = new (() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/BlazorGeolocation/geolocationJsInterop.js?v=0.1.1").AsTask());
        }

        public async ValueTask<BlazorGeolocationPosition> GetPositionAsync(bool enableHighAccuracy = false, double timeout = 5000, double maximumAge = 0)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<BlazorGeolocationPosition>("getCurrentPosition", enableHighAccuracy, timeout, maximumAge);
        }

        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}
