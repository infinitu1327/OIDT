using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Newtonsoft.Json;

namespace ImportRecords
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US");

            await JsonsToCsvs();
        }

        private static async Task JsonsToCsvs()
        {
            var jsons = Directory
                .EnumerateFiles(Directory.GetCurrentDirectory())
                .AsParallel()
                .Where(file => Path.GetExtension(file) == ".json" && !file.Contains("ImportRecords"));

            var countOfEvents = 0;

            for (var i = 0;; i++)
            {
                var batch = jsons.Skip(i * 20).Take(20);

                if (!batch.Any()) break;

                var eventsTasks = batch
                    .Select(async file => await File.ReadAllTextAsync(file))
                    .Select(async file => JsonConvert.DeserializeObject<IEnumerable<Event>>(await file));

                var eventsIEnumerables = await Task.WhenAll(eventsTasks);
                var events = eventsIEnumerables.SelectMany(ienumerable => ienumerable);

                foreach (var ev in events)
                {
                    countOfEvents++;

                    if (ev.Parameters.NotNull())
                    {
                        ev.ParametersId = countOfEvents;
                        ev.Parameters.Id = countOfEvents;
                    }

                    ev.Id = countOfEvents;
                }

                var parameters = events
                    .Select(e => e.Parameters)
                    .Where(p => p.NotNull())
                    .Select(p => p.ToString());

                await File.AppendAllLinesAsync("parameters.csv", parameters);
                await File.AppendAllLinesAsync("events.csv", events.Select(e => e.ToString()));

                Console.WriteLine(countOfEvents);
            }
        }
    }
}