using System;
using System.Collections.Generic;
using System.Linq;

namespace LinearRegression
{
    internal class Program
    {
        private static readonly Dictionary<double, double> Dau = new Dictionary<double, double>
        {
            {0, 131030},
            {1, 262770},
            {2, 394450},
            {3, 524500},
            {4, 656430},
            {5, 783130},
            {6, 917080},
            {7, 1045260},
            {8, 1176470},
            {9, 1303210},
            {10, 1431910},
            {11, 1563440},
            {12, 1697030},
            {13, 1828940},
            {14, 1957440},
            {15, 2088440},
            {16, 2225440},
            {17, 2349890},
            {18, 2480620},
            {19, 2612990},
            {20, 2740320},
            {21, 2871840},
            {22, 3010110},
            {23, 3138350},
            {24, 3266870},
            {25, 3397080},
            {26, 3523800},
            {27, 3654290},
            {28, 3788600},
            {29, 3922570}
        };

        private static readonly Dictionary<double, double> NewUsers = new Dictionary<double, double>
        {
            {0, 131030},
            {1, 131740},
            {2, 131680},
            {3, 130050},
            {4, 131930},
            {5, 126700},
            {6, 133950},
            {7, 128180},
            {8, 131210},
            {9, 126740},
            {10, 128700},
            {11, 131530},
            {12, 133590},
            {13, 131910},
            {14, 128500},
            {15, 131000},
            {16, 137000},
            {17, 124450},
            {18, 130730},
            {19, 132370},
            {20, 127330},
            {21, 131520},
            {22, 138270},
            {23, 128240},
            {24, 128520},
            {25, 130210},
            {26, 126720},
            {27, 130490},
            {28, 134310},
            {29, 133970}
        };

        private static readonly Dictionary<double, double> Revenue = new Dictionary<double, double>
        {
            {0, 69510},
            {1, 146500},
            {2, 214740},
            {3, 288230},
            {4, 357940},
            {5, 427020},
            {6, 503340},
            {7, 550350},
            {8, 645600},
            {9, 711240},
            {10, 780790},
            {11, 852520},
            {12, 932500},
            {13, 992740},
            {14, 1078850},
            {15, 1139960},
            {16, 1230840},
            {17, 1297050},
            {18, 1339800},
            {19, 1403680},
            {20, 1490410},
            {21, 1561020},
            {22, 1663400},
            {23, 1715240},
            {24, 1791300},
            {25, 1878500},
            {26, 1942520},
            {27, 1989680},
            {28, 2067190},
            {29, 2108060}
        };

        private static readonly Dictionary<double, double> BuyedItems = new Dictionary<double, double>
        {
            {0, 36790},
            {1, 71140},
            {2, 108630},
            {3, 150180},
            {4, 185240},
            {5, 227600},
            {6, 271490},
            {7, 313860},
            {8, 356980},
            {9, 401140},
            {10, 444430},
            {11, 496580},
            {12, 537050},
            {13, 587650},
            {14, 629220},
            {15, 682230},
            {16, 723180},
            {17, 766800},
            {18, 815450},
            {19, 865960},
            {20, 910760},
            {21, 958490},
            {22, 1012740},
            {23, 1055120},
            {24, 1102930},
            {25, 1145880},
            {26, 1197570},
            {27, 1245190},
            {28, 1294300},
            {29, 1340870}
        };

        private static readonly Dictionary<double, double> ItemsRevenue = new Dictionary<double, double>
        {
            {0, 16761363.0697552},
            {1, 32117179.8021567},
            {2, 47555223.4046841},
            {3, 63200884.7279163},
            {4, 76912881.7486835},
            {5, 94656558.5873633},
            {6, 112656656.127022},
            {7, 127583703.818442},
            {8, 141108486.045132},
            {9, 159134215.402162},
            {10, 175874150.272595},
            {11, 191915361.801496},
            {12, 207871988.333072},
            {13, 227056275.835269},
            {14, 238103691.649421},
            {15, 256504670.812762},
            {16, 271824808.055383},
            {17, 284901033.478081},
            {18, 307114899.266256},
            {19, 324232749.652006},
            {20, 338599280.761158},
            {21, 353629265.83114},
            {22, 371153124.204047},
            {23, 387796273.332087},
            {24, 402330744.108653},
            {25, 416280194.285545},
            {26, 434770782.282415},
            {27, 449963375.601798},
            {28, 464640974.446564},
            {29, 484585091.542905}
        };

        public static void Main(string[] args)
        {
            var dauLineEquation = GetLineEquation(Dau);
            var newUsersLineEquation = GetLineEquation(NewUsers);
            var revenueLineEquation = GetLineEquation(Revenue);
            var buyedItemsLineEquation = GetLineEquation(BuyedItems);
            var itemsRevenueLineEquatipn = GetLineEquation(ItemsRevenue);
        }

        private static LineEquation GetLineEquation(Dictionary<double, double> keyValuePairs)
        {
            var sumX = keyValuePairs.Sum(d => d.Key);
            var sumY = keyValuePairs.Sum(d => d.Value);
            var sumSquaredX = keyValuePairs.Sum(d => Math.Pow(d.Key, 2));
            var productXy = keyValuePairs.Select(d => d.Key * d.Value);
            var sumProductXy = productXy.Sum(el => el);
            var pairsCount = keyValuePairs.Count;

            var delta = sumSquaredX * pairsCount - sumX * sumX;

            var deltaA = sumProductXy * pairsCount - sumY * sumX;
            var a = deltaA / delta;

            var deltaB = sumSquaredX * sumY - sumX * sumProductXy;
            var b = deltaB / delta;

            return new LineEquation(a, b);
        }

        private static Dictionary<double, double> GetPredictions(LineEquation lineEquation, double countOfPredictions)
        {
            var result = new Dictionary<double, double>();

            for (var i = 0; i < countOfPredictions; i++) result.Add(i + 30, lineEquation.A * (i + 30) + lineEquation.B);

            return result;
        }
    }
}