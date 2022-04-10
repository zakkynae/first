using System;
using System.Collections.Generic;

namespace HomeWork
{
    internal class Program
    {
        public static List<string> GetFirstTriangle(int row)
        {
            var elementFirstTriangle = "";
            var firstTriangle = new List<string>() { elementFirstTriangle };
            for (var i = 0; i < row; i++)
                firstTriangle.Add(elementFirstTriangle += "*");
            return firstTriangle;
        }
        //public static string GetFirstTriangle(int row)
        //{
        // \n??
        //}

        public static List<string> GetSecondTriangle(int row)
        {
            var elementSecondTriangle = "";
            for(var i = 0; i < row-3; i++)
                elementSecondTriangle += " ";
            var secondTriangle = new List<string>() {(elementSecondTriangle += "*")};
            for(var i = 0; i < row - 3; i++)
            {
                elementSecondTriangle = elementSecondTriangle.Substring(1) + "**";
                secondTriangle.Add(elementSecondTriangle);
            }
            return secondTriangle;
        }

        public static void PrintTriangle(List<string> triangle)
        {
            foreach(var element in triangle)
                Console.WriteLine(element);
        }
   
        static void Main(string[] args)
        {
            Console.Write("Введите кол-во строк треугольника: ");

            int row;
            while(!(int.TryParse(Console.ReadLine(), out row)) || row < 3)
            {
                Console.WriteLine("Введено неверное кол-во строк треугольника. Попробуйте еще раз.");
            }
            PrintTriangle(GetFirstTriangle(row));
            Console.WriteLine();
            PrintTriangle(GetSecondTriangle(row));
        }
    }
}
