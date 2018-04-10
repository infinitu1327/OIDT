using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Lab3
{
    public class Program
    {
        public static async Task Main()
        {
            using (var context = new AppDbContext())
            {
                var difficultByDay = await GetDifficult(context);

                foreach (var difficult in difficultByDay) Console.WriteLine($"{difficult.Key}:{difficult.Value}");
            }
        }

        private static async Task<Dictionary<int, decimal>> GetDifficult(AppDbContext context)
        {
            return await context.StageEndParameters
                .AsNoTracking()
                .GroupBy(p => p.Stage)
                .ToDictionaryAsync(gr => gr.Key, gr =>
                {
                    var winsCount = gr.Count(p => p.Win);
                    var totalCount = gr.Count();
                    return (decimal) winsCount / totalCount;
                });
        }
    }
}