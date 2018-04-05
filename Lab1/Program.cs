using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleTables;
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
                var table = new ConsoleTable("Date", "Rate");

                var rates = await GetNewUsers(context);

                foreach (var rate in rates) table.AddRow(rate.Key.ToShortDateString(), rate.Value);

                table.Write();
            }
        }

        [Obsolete("Takes a very long time to execute")]
        public static async Task<Dictionary<DateTime, int>> GetDAU(AppDbContext context)
        {
            return await context.FirstLaunchEvents
                .AsNoTracking()
                .GroupBy(gr => gr.Date)
                .ToDictionaryAsync(gr => gr.Key, gr => gr.Select(e => e.Udid).Distinct().Count() * 10);
        }

        [Obsolete("Takes a very long time to execute")]
        private static async Task<Dictionary<DateTime, int>> GetNewUsers(AppDbContext context)
        {
            var previousCount = 0;

            return await context.FirstLaunchEvents
                .AsNoTracking()
                .GroupBy(e => e.Date)
                .ToDictionaryAsync(gr => gr.Key, gr =>
                {
                    var count = gr.Select(e => e.Udid).Distinct().Count() * 10;
                    var result = count - previousCount;
                    previousCount = count;
                    return result;
                });
        }

        private static async Task<Dictionary<DateTime, decimal>> GetRevenue(AppDbContext context)
        {
            return await context.CurrencyPurchaseEvents
                .Include(e => e.Parameters)
                .AsNoTracking()
                .GroupBy(e => e.Date)
                .ToDictionaryAsync(gr => gr.Key, gr => gr.Sum(g => g.Parameters.Price) * 10);
        }

        private static async Task<int> GetUniqueUsers(AppDbContext context)
        {
            return await context.GameLaunchEvents
                       .AsNoTracking()
                       .Select(e => e.Udid)
                       .Distinct()
                       .CountAsync() * 10;
        }

        private static async Task<Dictionary<DateTime, decimal>> GetCurrencyRate(AppDbContext context)
        {
            return await context.CurrencyPurchaseEvents
                .AsNoTracking()
                .Include(e => e.Parameters)
                .GroupBy(e => e.Date)
                .ToDictionaryAsync(gr => gr.Key,
                    gr => gr.Sum(e => e.Parameters.Price) / gr.Sum(e => e.Parameters.Income));
        }

        [Obsolete("Takes a very long time to execute")]
        private static async Task<Dictionary<DateTime, int>> CountOfStartedStages(AppDbContext context)
        {
            return await context.StageStartEvents
                .AsNoTracking()
                .GroupBy(e => e.Date)
                .ToDictionaryAsync(e => e.Key, e => e.Count() * 10);
        }

        [Obsolete("Takes a very long time to execute")]
        private static async Task<Dictionary<DateTime, int>> CountOfEndedStages(AppDbContext context)
        {
            return await context.StageEndEvents
                .AsNoTracking()
                .GroupBy(e => e.Date)
                .ToDictionaryAsync(e => e.Key, e => e.Count() * 10);
        }

        [Obsolete("Takes a very long time to execute")]
        private static async Task<Dictionary<DateTime, int>> CountOfWins(AppDbContext context)
        {
            return await context.StageEndEvents
                .AsNoTracking()
                .Include(e => e.Parameters)
                .GroupBy(e => e.Date)
                .ToDictionaryAsync(gr => gr.Key, gr => gr.Count(e => e.Parameters.Win) * 10);
        }

        [Obsolete("Takes a very long time to execute")]
        private static async Task<Dictionary<DateTime, int>> EarnedCurrencyAmount(AppDbContext context)
        {
            return await context.StageEndEvents
                .AsNoTracking()
                .Include(e => e.Parameters)
                .GroupBy(e => e.Date)
                .ToDictionaryAsync(gr => gr.Key,
                    gr => gr.Where(e => e.Parameters.Income.HasValue).Sum(e => e.Parameters.Income.Value) * 10);
        }

        [Obsolete("Takes a very long time to execute")]
        private static async Task<Dictionary<DateTime, int>> EarnedCurrencyAmountInUSD(AppDbContext context)
        {
            return await context.StageEndEvents
                .AsNoTracking()
                .Include(e => e.Parameters)
                .GroupBy(e => e.Date)
                .ToDictionaryAsync(gr => gr.Key,
                    gr => gr.Where(e => e.Parameters.Income.HasValue).Sum(e => e.Parameters.Income.Value) * 10);
        }
    }
}