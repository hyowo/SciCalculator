namespace SciCalculator;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("Cairo-Light.ttf", "CairoLight");
				fonts.AddFont("Cairo-ExtraLight.ttf", "CairoExtraLight");
			});

		return builder.Build();
	}
}
