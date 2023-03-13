#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif
using SciCalculator.Views;

namespace SciCalculator;


public partial class App : Application
{
	public App()
	{
		InitializeComponent();
#if WINDOWS
		Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
		{
			var nativeWindow = handler.PlatformView;
			nativeWindow.Activate();
			IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
			WindowId windowId = Win32Interop.GetWindowIdFromWindow(windowHandle);
			AppWindow.GetFromWindowId(windowId).Resize(new SizeInt32(540, 1000));
		});
#endif
        MainPage = new CalculatorPage() {};
	}
}