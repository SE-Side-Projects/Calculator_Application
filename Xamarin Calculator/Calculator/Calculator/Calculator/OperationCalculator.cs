using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public static class OperationCalculator
    {
        public static double Calculate(double first, double second, string mathOperator)
        {
            double result = 0;

            switch (mathOperator)
            {
                case "+":
                    result = first + second;
                    break;
                case "-":
                    result = first - second;
                    break;
                case "*":
                    result = first * second;
                    break;
                case "/":
                    result = first / second;
                    break;
            }

            return result;

        }

        public static double Square(double first)
        {
            double result = 0;

            result = first * first;

            return result;
        }

        

    }

}
