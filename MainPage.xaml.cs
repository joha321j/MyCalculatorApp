using System;
using System.Globalization;
using Xamarin.Forms;

namespace MyCalculatorApp
{
    public partial class MainPage
    {
        private int _currentState;
        private string _mathOperator;
        private string _firstNumber;
        private string _secondNumber;

        public MainPage()
        {
            InitializeComponent();
            _currentState = 1;
        }

        private void OnSelectNumber(Object sender, EventArgs args)
        {
            Button clickedButton = sender as Button;

            if (_currentState < 0)
            {
                _currentState *= -1;
            }

            if (_currentState == 1)
            {
                if (clickedButton != null) _firstNumber += clickedButton.Text;
                ResultField.Text = _firstNumber;
            }
            else
            {
                if (clickedButton != null) _secondNumber += clickedButton.Text;
                ResultField.Text = _secondNumber;
            }
                
        }

        private void OnSelectOperator(Object sender, EventArgs args)
        {
            Button clickedButton = sender as Button;

            _currentState = -2;
            if (clickedButton != null) _mathOperator = clickedButton.Text;
        }

        private void OnClear(Object sender, EventArgs args)
        {
            _currentState = 1;
            ResultField.Text = "0";
            _firstNumber = "";
            _secondNumber = "";
        }

        private void OnCalculate(Object sender, EventArgs args)
        {
            _currentState = -1;
            double firstNumber = double.Parse(_firstNumber);
            double secondNumber = double.Parse(_secondNumber);

            String result = "";
            switch (_mathOperator)
            {
                case "+":
                    result = (firstNumber + secondNumber).ToString(CultureInfo.InvariantCulture);
                    break;
                case "/":
                    result = (firstNumber / secondNumber).ToString(CultureInfo.CurrentCulture);
                    break;
                case "-":
                    result = (firstNumber - secondNumber).ToString(CultureInfo.InvariantCulture);
                    break;
                case "X":
                    result = (firstNumber * secondNumber).ToString(CultureInfo.InvariantCulture);
                    break;
            }

            ResultField.Text = result;
            _firstNumber = result;
        }

        private async void OnClickHelloWorldPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HelloWorldPage());
        }
    }
}
