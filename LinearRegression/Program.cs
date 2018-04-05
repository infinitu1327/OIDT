using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinearRegression
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var dict = new Dictionary<int, int>
            {
                {1, 131030},
                {2, 262770},
                {3, 394450},
                {4, 524500},
                {5, 656430},
                {6, 783130},
                {7, 917080},
                {8, 1045260},
                {9, 1176470},
                {10, 1303210},
                {11, 1431910},
                {12, 1563440},
                {13, 1697030},
                {14, 1828940},
                {15, 1957440},
                {16, 2088440},
                {17, 2225440},
                {18, 2349890},
                {19, 2480620},
                {20, 2612990},
                {21, 2740320},
                {22, 2871840},
                {23, 3010110},
                {24, 3138350},
                {25, 3266870},
                {26, 3397080},
                {27, 3523800},
                {28, 3654290},
                {29, 3788600},
                {30, 3922570}
            };
            var sumX = dict.Select(d => d.Key).Sum();
            var sumY = dict.Select(d => d.Value).Sum();
            var squaredSumX = dict.Select(d => Math.Pow(d.Key, 2)).Sum();
            var productXY = dict.Select(d => d.Key * d.Value);
            var sumProductXY = productXY.Sum(el=>(long)el);
            var n = dict.Count;
            var delta = squaredSumX * n - sumX * sumX;
            var deltaA = sumProductXY * n - sumY * sumX;
            var a = deltaA / delta;
            var deltaB = squaredSumX * sumY - sumX * sumProductXY;
            var b = deltaB / delta;

            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}