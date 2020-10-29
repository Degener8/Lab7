using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Lab7
{
    class Program
    {


        static bool CheckFile(string path)
        {
            if (File.Exists(path) && (File.ReadAllText(path) != string.Empty))
                return true;
            else
            {
                Console.WriteLine("Файл не обнаружен или пуст");
                return false;
            }
        }

        static bool LookForExpression(string path)
        {
            string[] input = File.ReadAllText(path).Replace('.', ',').Split(' ');
            if (Double.TryParse(input[0], out double first)
                && (input[1] == "/")
                && (Double.TryParse(input[2], out double second))
                && (input.Length == 3)
                && (second == 0))
            {
                Console.WriteLine("Недопустимая операция");
                return false;
            }
            else if (Double.TryParse(input[0], out double uno)
                && (input[1] == "+" || input[1] == "/" || input[1] == "*" || input[1] == "-")
                && (Double.TryParse(input[2], out double tres))
                && input.Length == 3)
                return true;
            else
            {
                Console.WriteLine("Недопустимая операция");
                return false;
            }

        }

        static double ExecuteExpression(string[] input)
        {
            double result = 0;
            if (input[1] == "+")
                result = Convert.ToDouble(input[0]) + Convert.ToDouble(input[2]);
            else if (input[1] == "-")
                result = Convert.ToDouble(input[0]) - Convert.ToDouble(input[2]);
            else if (input[1] == "*")
                result = Convert.ToDouble(input[0]) * Convert.ToDouble(input[2]);
            else if (input[1] == "/" && Convert.ToDouble(input[2]) != 0)
                result = Convert.ToDouble(input[0]) - Convert.ToDouble(input[2]);

            return result;
        }

        static void Main(string[] args)
        {
            string path = "input.txt";

            if (CheckFile(path))
            {
                if (LookForExpression(path))
                {
                    string[] input = File.ReadAllText(path).Replace('.', ',').Split(' ');
                    File.WriteAllText("output.txt", ExecuteExpression(input).ToString());
                    Console.WriteLine("Результат выражения записан в файл outup.txt");
                }
            }
        }
    }
}
