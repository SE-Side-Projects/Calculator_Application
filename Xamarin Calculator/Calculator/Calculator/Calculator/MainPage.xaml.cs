using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {

        string mathOperator;
        string userInput = "";
        string firstInput = "";
        string secondInput = "";
        double firstNumber, secondNumber;
        bool operationDone = false;
        public MainPage()
        {
            InitializeComponent();
            OnClear(this, null);
        }

        private void OnSelectNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;

            if (operationDone)
            {
                mainLabel.Text = "";
                userInput = "";
                operationDone = false;
            }

            mainLabel.Text = "";
            topLabel.Text = "";
            userInput += pressed;
            mainLabel.Text += userInput;
            
        }

        void OnSelectDecimal(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;
            mainLabel.Text += pressed;
        }

        void OnSelectSquare(object sender, EventArgs e)
        {
            firstInput = userInput;
            double result = OperationCalculator.Square(Convert.ToDouble(firstInput));
            userInput = result.ToString();
            mainLabel.Text = result.ToString();
            topLabel.Text = Convert.ToDouble(firstInput) + "² " + " = " + result.ToString();

        }

        void OnSelectOperator(object sender, EventArgs e)
        {
            firstInput = userInput;
            Button button = (Button)sender;
            string pressed = button.Text;
            mathOperator = pressed;
            mainLabel.Text += " " + mathOperator;
            userInput = "";

        }

        void OnCalculate(object sender, EventArgs e)
        {
            secondInput = userInput;

            try
            {
                
                firstNumber = Convert.ToDouble(firstInput);
                secondNumber = Convert.ToDouble(secondInput);

                double result = OperationCalculator.Calculate(firstNumber, secondNumber, mathOperator);
                mainLabel.Text = result.ToString();
                topLabel.Text = firstNumber.ToString() + " " + mathOperator + " " + secondNumber + " = ";
                firstNumber = result;

                userInput = result.ToString();
                operationDone = true;
            }
            catch (FormatException)
            {
                topLabel.Text = "Error";
                mainLabel.Text = "Error";
            }
        }

        void OnClear(object sender, EventArgs e)
        {
            userInput = "";
            firstInput = "";
            secondInput = "";
            mainLabel.Text = "0";
            topLabel.Text = " ";
            operationDone = false;
        }

        void BtnRadical_clicked(object sender, EventArgs e)
        {
            firstInput = userInput;
            double result = Math.Sqrt(Convert.ToDouble(firstInput));
            userInput = result.ToString();
            mainLabel.Text = result.ToString();
            topLabel.Text = "²√ " + Convert.ToDouble(firstInput) + " = " + result.ToString();
        }
    }
}
