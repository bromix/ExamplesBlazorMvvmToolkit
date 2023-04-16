using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExamplesBlazorMvvmToolkit.Data;

namespace ExamplesBlazorMvvmToolkit.ViewModels;

internal sealed partial class WeatherViewModel3 : ObservableObject
{
    private readonly WeatherForecastService _weatherService;

    public WeatherViewModel3(WeatherForecastService weatherService)
    {
        _weatherService = weatherService;
    }

    [ObservableProperty] private WeatherForecast[] _forecasts = Array.Empty<WeatherForecast>();

    [RelayCommand]
    private async Task Load(TimeSpan delay, CancellationToken cancellationToken)
    {
        try
        {
            await Task.Delay(delay, cancellationToken); // simulate loading
            Forecasts = await _weatherService.GetForecastAsync(DateOnly.FromDateTime(DateTime.Now));
        }
        catch (OperationCanceledException)
        {
            /*
             * This is okay to catch and in this case to ignore. The Cancellation will throw an
             * OperationCanceledException. For information read the following link:
             * 
             * https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception
             */
        }
    }
}