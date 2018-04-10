using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Lab1
{
    public class Program
    {
        public static async Task Main()
        {
            using (var context = new AppDbContext())
            {
                var newUsers = await GetNewUsers(context);

                foreach (var newUser in newUsers) Console.WriteLine($"{newUser.Key}:{newUser.Value}");
            }
        }

        private static async Task<Dictionary<DateTime, int>> GetNewUsers(AppDbContext context)
        {
            var previousDayCount = 0;

            var dict = await context.FirstLaunchEvents
                .AsNoTracking()
                .GroupBy(e => e.Date)
                .ToDictionaryAsync(e => e.Key, e =>
                {
                    var count = e.Select(ev => ev.Udid).Distinct().Count() * 10;
                    var result = count - previousDayCount;
                    previousDayCount = count;
                    return result;
                });

            return dict;
        }
    }
}