using System;


namespace HomeWork3
{
    internal class Program
    {
        static double GetArithmeticMean(double firstNumber, double secondNumber, double thirdNumber) => (firstNumber + secondNumber + thirdNumber) / 3;
        static double GetGeometricMean(double firstNumber, double secondNumber, double thirdNumber) => Math.Pow(firstNumber * secondNumber * thirdNumber, 1 / 3.0);
        static double GetNumber (int min, int max) => new Random().Next(min, max);
        static double RoundNumber (double number, int digit) => Math.Round(number, digit);
        


        static void Main(string[] args)
        {
            Console.Write("Введите диапазон генерации чисел.\nМинимум: ");
            int min;
            while(!int.TryParse(Console.ReadLine(), out min))
            {
                Console.WriteLine("Введено некорректное значение. Попробуйте еще раз.");
            }
            Console.Write("Максимум: ");
            int max;
            while(!int.TryParse(Console.ReadLine(), out max) || max < min)
            {
                Console.WriteLine("Введено некорректное значение. Попробуйте еще раз.");
            }            
            var firstNumber = GetNumber(min, max);
            var secondNumber = GetNumber(min, max);
            var thirdNumber = GetNumber(min, max);
            Console.WriteLine($"{firstNumber} {secondNumber} {thirdNumber}");
            Console.WriteLine($"Среднее арифмитическое: {GetArithmeticMean(firstNumber, secondNumber, thirdNumber)}");
            Console.WriteLine($"Среднее геометрическое: {GetGeometricMean(firstNumber, secondNumber, thirdNumber)}");

            Console.Write("Введите разрядность, до которой хотите округлить: ");
            int digit;
            while (!int.TryParse(Console.ReadLine(), out digit) || digit < 0)
            {
                Console.WriteLine("Введено некорректное значение. Попробуйте еще раз.");
            }
            Console.WriteLine($"Среднее арифмитическое: {RoundNumber(GetArithmeticMean(firstNumber, secondNumber, thirdNumber), digit)}");
            Console.WriteLine($"Среднее геометрическое: {RoundNumber(GetGeometricMean(firstNumber, secondNumber, thirdNumber), digit)}");
        }
    }
}
