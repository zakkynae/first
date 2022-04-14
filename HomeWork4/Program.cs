using System;

namespace HomeWork4
{
    internal class Program
    {
        static int GetDigit (int number)
        {
            var digit = 0;
            var length = number.ToString().Length;
            while (length > 0)
            {
                length--;
                digit++;
            }
            return digit;
        }
        static int GetNewNumber(int number)
        {
            var numberString = number.ToString();
            var newNumber = "";
            for(int i = 0; i < numberString.Length; i++)
            {
                if(Char.GetNumericValue(numberString[i]) % 2 != 0)
                {
                    var newElement = Char.GetNumericValue(numberString[i]) + 1;
                    newNumber += newElement;
                }
                else newNumber += numberString[i];
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
