namespace SciCalculator.Views;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;
        CounterBtn.Text = $"Clicked {count} " + (count == 1 ? "time." : "times.");

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}

