﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Models.Events;
using Models.Parameters;
using Utf8Json;

namespace ImportRecords
{
    public class Program
    {
        private static async Task Main()
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US");

            await JsonsToCsvs();
        }

        private static async Task JsonsToCsvs()
        {
            var sw = new Stopwatch();
            sw.Start();

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
                    .Select(async file => JsonSerializer.Deserialize<IEnumerable<JsonEvent>>(await file));

                var eventsIEnumerables = await Task.WhenAll(eventsTasks);
                var events = eventsIEnumerables
                    .SelectMany(ienumerable => ienumerable);

                foreach (var e in events)
                {
                    e.Id = countOfEvents;
                    if (e.EventId == 1) continue;
                    e.Parameters.Id = countOfEvents;
                    countOfEvents++;
                }

                await File.AppendAllLinesAsync("C:\\csv\\FirstLaunchParameters.csv",
                    events.Where(e => e.EventId == 2).Select(e => new FirstLaunchParameters(e.Parameters).ToString()));

                await File.AppendAllLinesAsync("C:\\csv\\StageStartParameters.csv",
                    events.Where(e => e.EventId == 3).Select(e => new StageStartParameters(e.Parameters).ToString()));

                await File.AppendAllLinesAsync("C:\\csv\\StageEndParameters.csv",
                    events.Where(e => e.EventId == 4).Select(e => new StageEndParameters(e.Parameters).ToString()));

                await File.AppendAllLinesAsync("C:\\csv\\InGamePurchaseParameters.csv",
                    events.Where(e => e.EventId == 5)
                        .Select(e => new InGamePurchaseParameters(e.Parameters).ToString()));

                await File.AppendAllLinesAsync("C:\\csv\\CurrencyPurchaseParameters.csv",
                    events.Where(e => e.EventId == 6)
                        .Select(e => new CurrencyPurchaseParameters(e.Parameters).ToString()));

                await File.AppendAllLinesAsync("C:\\csv\\GameLaunchEvents.csv",
                    events.Where(e => e.EventId == 1).Select(e => e.ToString()));
                await File.AppendAllLinesAsync("C:\\csv\\FirstLaunchEvents.csv",
                    events.Where(e => e.EventId == 2).Select(e => e.ToString()));
                await File.AppendAllLinesAsync("C:\\csv\\StageStartEvents.csv",
                    events.Where(e => e.EventId == 3).Select(e => e.ToString()));
                await File.AppendAllLinesAsync("C:\\csv\\StageEndEvents.csv",
                    events.Where(e => e.EventId == 4).Select(e => e.ToString()));
                await File.AppendAllLinesAsync("C:\\csv\\InGamePurchaseEvents.csv",
                    events.Where(e => e.EventId == 5).Select(e => e.ToString()));
                await File.AppendAllLinesAsync("C:\\csv\\CurrencyPurchaseEvents.csv",
                    events.Where(e => e.EventId == 6).Select(e => e.ToString()));

                Console.WriteLine(countOfEvents);
            }

            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }
    }
}