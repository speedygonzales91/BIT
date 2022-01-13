using Microsoft.JSInterop;

namespace BIT_Client.Helper
{
    public static class IJSRuntimeExtension
    {
        public static async ValueTask GetSelectedText(this IJSRuntime jSRuntime)
        {
            await jSRuntime.InvokeVoidAsync("getSelectedText");
        }
    }
}
