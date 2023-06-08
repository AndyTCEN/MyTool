using _20230608_DelegatePic.Delegate;
using System;

namespace _20230608_DelegatePic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("請輸入+或-");
            string fun = Console.ReadLine();
            Console.WriteLine("請輸入數字A");
            string A = Console.ReadLine();
            Console.WriteLine("請輸入數字B");
            string B = Console.ReadLine();
            Console.WriteLine("請輸入數字C");
            string C = Console.ReadLine();

            int intA = int.TryParse(A,  out int resultA)?resultA:0;
            int intB = int.TryParse(B, out int resultB) ? resultB : 0;
            int intC = int.TryParse(C, out int resultC) ? resultC : 0;

            CountFunctionDelegate countFunctionDelegate = new CountFunctionDelegate();
            var result = countFunctionDelegate.Counting(fun, intA, intB,intC);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
