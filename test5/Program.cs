using System;
using System.Collections.Generic;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var List = Input();
            if (List == null)
            {
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
            Console.WriteLine("Enter count of segments: ");
            if (!(int.TryParse(Console.ReadLine(), out int n)))
            {
                Console.WriteLine("You entered wrong value");
                return null;
            }
            var L = new List<Coords>();
            for (var i = 0; i < n; ++i)
            {
                var temp = Console.ReadLine().Split();
                var coord = new int[2];
                if (!((int.TryParse(temp[0], out coord[0]) && (int.TryParse(temp[1], out coord[1])))) || (coord[0]>coord[1]))
                {
                    Console.WriteLine("You entered wrong value");
                    return null;
                }
                L.Add(new Coords(coord));
            }
            return L;
        }
    }
}
