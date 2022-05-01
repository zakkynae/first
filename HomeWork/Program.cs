using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace HomeWork
{   
    [MemoryDiagnoser]
    public class Logic
    {
        [Params(10, 100, 500)]
        public  int Row { get; set; }
        [Benchmark]
        public  string GetTriangleStringBuilder()
        {
            var row = Row;
            var triangle = new StringBuilder("");
            for (int i = 1; i < row + 1; i++)
            {
                triangle.Append(new String('*', i));
                triangle.Append('\n');
            }
            return triangle.ToString();
        }
        [Benchmark]
        public  List<string> GetTriangleListString()
        {
            var row = Row;
            var elementFirstTriangle = "";
            var firstTriangle = new List<string>() { elementFirstTriangle };
            for (var i = 0; i < row; i++)
                firstTriangle.Add(elementFirstTriangle += "*");
            return firstTriangle;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Logic>();
        }
    }
}
