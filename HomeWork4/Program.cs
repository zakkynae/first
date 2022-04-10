using System;

namespace HomeWork4
{
    internal class Program
    {
        static int GetDigit(int number) => number.ToString().Length;

        static int GetNewNumber(int number)
        {
            var newNumber = number.ToString();
            for(int i = 0; i < newNumber.Length; i++)
            {
                if (int.Parse(newNumber[i].ToString()) % 2 != 0)
                {
                    var newElement = int.Parse(newNumber[i].ToString()) + 1;
                    newNumber = newNumber.Replace(newNumber[i], char.Parse(newElement.ToString()));//
                }
                else continue;
            }
            return int.Parse(newNumber);
        }


        static void Main(string[] args)
        {
            Console.Write("Введите число: ");

            int number;
            while(!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Введено некорректное значение. Попробуйте еще раз.");
            }
            Console.WriteLine($"Разрядность числа {number} - {GetDigit(number)}");
            Console.WriteLine($"Перобразованное число - {GetNewNumber(number)}");
        }
    }
}
