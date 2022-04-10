using System;

namespace HomeWork2
{
    internal class Program
    {
        static int GetFactorial(int number)
        {
            int factorial = 1;
            if (number == 0)
                return factorial;
            else
            {
                for (int i = 1; i < number + 1; i++)
                    factorial *= i;
                return factorial;
            }

        }
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");

            int number;
            while(!int.TryParse(Console.ReadLine(), out number) || number < 0)
            {
                Console.WriteLine("Введено некорректное значение. Попробуйте еще раз: ");
            }

            Console.WriteLine($"{number}! = {GetFactorial(number)}");
        }
    }
}
