using CommunityToolkit.Mvvm.Input;
using System.Text.RegularExpressions;

namespace SciCalculator.Models.ViewModels
{
    public partial class CalculatorPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string inputText = string.Empty;

        [ObservableProperty]
        private string calculatedResult = "0";

        [ObservableProperty]
        private bool isSciOpWaiting = false;

        public CalculatorPageViewModel(string inputText, string calculatedResult, bool isSciOpWaiting)
        {
            this.inputText = inputText;
            this.calculatedResult = calculatedResult;
            this.isSciOpWaiting = isSciOpWaiting;
        }

        [RelayCommand]
        private void Reset()
        {
            InputText = string.Empty;
            IsSciOpWaiting = false;
            CalculatedResult = "0";
        }

        [RelayCommand]
        private void Calculate()
        {
            if (string.IsNullOrEmpty(InputText)) return;
            InputText += (IsSciOpWaiting ? ")" : "");
            IsSciOpWaiting = false;
            try
            {
                string normalizedString = NormalizeString(InputText);
                var expression = new NCalc.Expression(normalizedString);
                _ = expression.Evaluate();
            }
            catch
            {

            }
        }

        private static string NormalizeString(string inputText) => Regex.Replace(inputText, @"\b\w+\b", match => match.Value[..1] + match.Value[1..].ToLowerInvariant()).Replace("÷", "/").Replace("×", "*");

        [RelayCommand]
        private void Backspace() => InputText = InputText.Length > 0 ? InputText[..^1] : InputText;

        [RelayCommand]
        private void NumberInput(string key) => InputText += key;

        [RelayCommand]
        private void MathOperator(string op) => InputText += IsSciOpWaiting ? ")" : "" + $" {op} ";

        [RelayCommand]
        private void RegionOperator(string op) => InputText += op == ")" ? (IsSciOpWaiting = false, op) : op;

        [RelayCommand]
        private void ScientificOperator(string op) => (InputText, IsSciOpWaiting) = (InputText+$"{op}(", true);
    }
}
