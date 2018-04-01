﻿using System;
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
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

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
                    .Select(async file => JsonConvert.DeserializeObject<IEnumerable<JsonEvent>>(await file, settings));

                var eventsIEnumerables = await Task.WhenAll(eventsTasks);
                var events = eventsIEnumerables
                    .SelectMany(ienumerable => ienumerable)
                    .Select(e =>
                    {
                        e.Id = countOfEvents;
                        e.Parameters.Id = countOfEvents;
                        countOfEvents++;
                        return e;
                    });

                await File.AppendAllLinesAsync("GameLaunchParameters.csv",
                    events.Where(e => e.EventId == 1).Select(e => new GameLaunchParameters(e.Parameters).ToString()));

                await File.AppendAllLinesAsync("FirstLaunchParameters.csv",
                    events.Where(e => e.EventId == 2).Select(e => new FirstLaunchParameters(e.Parameters).ToString()));

                await File.AppendAllLinesAsync("StageStartParameters.csv",
                    events.Where(e => e.EventId == 3).Select(e => new StageStartParameters(e.Parameters).ToString()));

                await File.AppendAllLinesAsync("StageEndParameters.csv",
                    events.Where(e => e.EventId == 4).Select(e => new StageEndParameters(e.Parameters).ToString()));

                await File.AppendAllLinesAsync("InGamePurchaseParameters.csv",
                    events.Where(e => e.EventId == 5)
                        .Select(e => new InGamePurchaseParameters(e.Parameters).ToString()));

                await File.AppendAllLinesAsync("CurrencyPurchaseParameters.csv",
                    events.Where(e => e.EventId == 6)
                        .Select(e => new CurrencyPurchaseParameters(e.Parameters).ToString()));

                await File.AppendAllLinesAsync("Events.csv", events.Select(e => e.ToString()));

                Console.WriteLine(countOfEvents);
            }
        }
    }
}