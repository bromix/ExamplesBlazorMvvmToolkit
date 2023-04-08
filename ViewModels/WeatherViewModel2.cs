using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExamplesBlazorMvvmToolkit.Data;

namespace ExamplesBlazorMvvmToolkit.ViewModels;

internal sealed partial class WeatherViewModel2 : ObservableObject
{
    private readonly WeatherForecastService _weatherService;

    public WeatherViewModel2(WeatherForecastService weatherService)
    {
        _weatherService = weatherService;
    }

    [ObservableProperty] private WeatherForecast[] _forecasts = Array.Empty<WeatherForecast>();

    [RelayCommand]
    private async Task Load()
    {
        await Task.Delay(TimeSpan.FromSeconds(2)); // simulate loading
        Forecasts = await _weatherService.GetForecastAsync(DateOnly.FromDateTime(DateTime.Now));
    }
}