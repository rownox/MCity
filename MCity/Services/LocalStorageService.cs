using Microsoft.JSInterop;

namespace MCity.Services {
   public class LocalStorageService {
      private readonly IJSRuntime _jsRuntime;

      public LocalStorageService(IJSRuntime jsRuntime) {
         _jsRuntime = jsRuntime;
      }

      public ValueTask<string> GetItem(string key) =>
          _jsRuntime.InvokeAsync<string>("localStorage.getItem", key);

      public ValueTask SetItem(string key, string value) =>
          _jsRuntime.InvokeVoidAsync("localStorage.setItem", key, value);
   }
}
