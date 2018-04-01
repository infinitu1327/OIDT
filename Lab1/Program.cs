using System.Linq;
using Lab1.Context;
using Models;

namespace Lab1
{
    public class Program
    {
        public static void Main()
        {
            using (var context = new AppDbContext())
            {
                var dau=context.Events
                    .Where(e => e.EventId == 1)
                    .GroupBy(e => e.Date)
                    .Select(gr => new DAU { Date = gr.Key, Count = gr.Count() * 10 });

                context.DAU.AddRangeAsync(dau);

                var uniqueUsers = context.Events
                    .Where(e => e.EventId == 2)
                    .GroupBy(e => e.Date)
                    .Select(gr => new UniqueUsers {Date = gr.Key, Count = gr.Count() * 10});

                context.UniqueUsers.AddRangeAsync(uniqueUsers);

                var revenue = context.Events
                    .Where(e => e.EventId == 6)
                    .GroupBy(e => e.Date);
            }
        }
    }
}