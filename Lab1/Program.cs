using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Lab1.Context;
using Microsoft.EntityFrameworkCore.Internal;
using Models;

namespace Lab1
{
    public class Program
    {
        public static void Main()
        {
            using (var context = new AppDbContext())
            {
                var dau = context
                    .Events
                    .Where(e => e.EventId == 2)
                    .GroupBy(e => e.Date);

                Console.WriteLine($"Count of daily unique users:");

                var newUsersCount = 0;
                var previousDayUsersCount = 0;

                foreach (var ev in dau)
                {
                    var dailyUserCount = ev.Count();
                    var dailyNewUsersCount = dailyUserCount - previousDayUsersCount;
                    newUsersCount += dailyNewUsersCount;
                    previousDayUsersCount = dailyUserCount;
                    Console.WriteLine($"{ev.Key}:{dailyUserCount}");
                    Console.WriteLine($"Daily new users count:{dailyNewUsersCount}");
                }

                Console.WriteLine($"Total new user count:{newUsersCount}");

                Console.WriteLine($"Count of new users:{newUsersCount}");

                var uniqueUsersCount = context.Events
                    .Distinct()
                    .Count();

                Console.WriteLine($"Unique users count:{uniqueUsersCount}");

                var revenue = context.Events
                    .Where(e => e.EventId == 6)
                    .GroupBy(e => e.Date, e => e.Parameters);

                Console.WriteLine(revenue);

                var dailyPriceCourse = context.Events
                    .Where(e => e.EventId == 6)
                    .GroupBy(e => e.Date)
                    .ToDictionary(gr => gr.Key, gr => gr.Select(g => g.Parameters.Price).Sum() / gr.Select(g => g.Parameters.Income).Sum());

                foreach (var course in dailyPriceCourse)
                {
                    Console.WriteLine($"{course.Key}:{course.Value}");
                }

                var winsCount = context.Parameters
                    .Count(p => p.Win == true);

                Console.WriteLine($"Wins count:{winsCount}");

                var totalStagesIncome = context.Events
                    .Where(e => e.EventId == 4)
                    .Select(e => e.Parameters)
                    .Count(p => p.Income != null);

                Console.WriteLine($"Total stages incom:{totalStagesIncome}");

                var purchasedItemsCount = context.Events.Count(e => e.EventId == 5);

                Console.WriteLine($"Count of purchased items:{purchasedItemsCount}");
            }
        }
    }
}