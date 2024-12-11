using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var digits = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var result = GetPermutations(digits, digits.Length)
                .Select(p => p.ToArray())
                .Where(p => IsValidNumber(p))
                .Select(p => int.Parse(string.Join("", p)))
                .FirstOrDefault();

            if (result == 0)
            {
                Console.WriteLine("Nijedan broj ne zadovoljava uslove.");
            }
            else
            {
                Console.WriteLine($"Traženi broj je: {result}");
            }
            Console.ReadLine();//trazeni broj 381654729
        }
        static IEnumerable<IEnumerable<T>> GetPermutations<T>(T[] items, int count)
        {
            if (count == 1) return items.Select(t => new T[] { t });
            return GetPermutations(items, count - 1)
                .SelectMany(t => items.Where(e => !t.Contains(e)),
                            (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        static bool IsValidNumber(int[] digits)
        {
            int num = 0;
            for (int i = 0; i < digits.Length; i++)
            {
                num = num * 10 + digits[i];
                if (num % (9 - i) != 0)
                    return false;
            }
            return true;
        }
    }
}
