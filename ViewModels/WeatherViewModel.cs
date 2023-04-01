using CommunityToolkit.Mvvm.ComponentModel;
using ExamplesBlazorMvvmToolkit.Data;

namespace ExamplesBlazorMvvmToolkit.ViewModels;

internal sealed partial class WeatherViewModel : ObservableObject
{
    private readonly WeatherForecastService _weatherService;

    public WeatherViewModel(WeatherForecastService weatherService)
    {
        _weatherService = weatherService;
    }

    [ObservableProperty] private bool _isLoading;

    [ObservableProperty] private WeatherForecast[] _forecasts = Array.Empty<WeatherForecast>();

    public async Task LoadDataAsync()
    {
        IsLoading = true;

        try
        {
            await Task.Delay(TimeSpan.FromSeconds(2)); // simulate loading
            Forecasts = await _weatherService.GetForecastAsync(DateOnly.FromDateTime(DateTime.Now));
        }
        finally
        {
            IsLoading = false;
        }
    }
}