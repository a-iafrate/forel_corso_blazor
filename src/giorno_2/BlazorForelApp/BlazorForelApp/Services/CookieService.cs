using Microsoft.JSInterop;
using System.Text.Json;

namespace BlazorForelApp.Services;

public interface ICookieService
{
    Task<string?> GetCookieAsync(string name);
    Task SetCookieAsync(string name, string value, int? expireDays = null);
    Task<T?> GetCookieAsync<T>(string name) where T : class;
    Task SetCookieAsync<T>(string name, T value, int? expireDays = null) where T : class;
    Task DeleteCookieAsync(string name);
    Task<IEnumerable<string>> GetAllCookieNamesAsync();
}

public class CookieService : ICookieService
{
    private readonly IJSRuntime _jsRuntime;

    public CookieService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<string?> GetCookieAsync(string name)
    {
        try
        {
            return await _jsRuntime.InvokeAsync<string?>("getCookie", name);
        }
        catch
        {
            return null;
        }
    }

    public async Task SetCookieAsync(string name, string value, int? expireDays = null)
    {
        try
        {
            await _jsRuntime.InvokeVoidAsync("setCookie", name, value, expireDays);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Errore nel salvare il cookie: {ex.Message}", ex);
        }
    }

    public async Task<T?> GetCookieAsync<T>(string name) where T : class
    {
        try
        {
            var cookieValue = await GetCookieAsync(name);
            if (string.IsNullOrEmpty(cookieValue))
                return null;

            return JsonSerializer.Deserialize<T>(cookieValue);
        }
        catch
        {
            return null;
        }
    }

    public async Task SetCookieAsync<T>(string name, T value, int? expireDays = null) where T : class
    {
        try
        {
            var jsonValue = JsonSerializer.Serialize(value);
            await SetCookieAsync(name, jsonValue, expireDays);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Errore nel serializzare e salvare il cookie: {ex.Message}", ex);
        }
    }

    public async Task DeleteCookieAsync(string name)
    {
        try
        {
            await _jsRuntime.InvokeVoidAsync("deleteCookie", name);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Errore nel cancellare il cookie: {ex.Message}", ex);
        }
    }

    public async Task<IEnumerable<string>> GetAllCookieNamesAsync()
    {
        try
        {
            var result = await _jsRuntime.InvokeAsync<string[]>("getAllCookieNames");
            return result ?? Array.Empty<string>();
        }
        catch
        {
            return Array.Empty<string>();
        }
    }
}