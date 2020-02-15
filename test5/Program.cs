using System;
using System.Collections.Generic;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var List = Input();
            if(List==null)
            {
                Console.WriteLine("You entered wrong values");
                return;
            }
            var sum = Func(List);
            Console.WriteLine(sum);
            Console.Read();
        }

        private static int Func(List<Coords> L)
        {
            L.Sort((x, y) => x.Left.CompareTo(y.Left));
            for (var i = 1; i < L.Count; ++i)
            {
                if (L[i].Right <= L[i - 1].Right)
                {
                    L.Remove(L[i]);
                    i--;
                    continue;
                }
                if (L[i].Left <= L[i - 1].Right && L[i].Right > L[i - 1].Right)
                {
                    L[i - 1].Right = L[i].Right;
                    L.Remove(L[i]);
                    i--;
                    continue;
                }
            }
            int sum = 0;
            for (var i = 0; i < L.Count; ++i)
                sum += L[i].Right - L[i].Left;
            return sum;
        }

        private static List<Coords> Input()
        {
            if (!(int.TryParse(Console.ReadLine(), out int n)))
            {
                return null;
            }
            var L = new List<Coords>();
            for (var i = 0; i < n; ++i)
                L.Add(new Coords(Console.ReadLine().Split()));
            return L;
        }
    }
}
