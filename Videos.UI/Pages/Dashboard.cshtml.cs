using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Videos.Database;
using System.Configuration;

namespace Videos.UI.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DashboardModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            SetCreatedCountByMonth();
            DiggPlayList = SetDiggPlayList();
            SetDurationCategory();
            SetAveragePlayByMonth("playCount", AveragePlayByMonth);
            SetAveragePlayByMonth("diggCount", AverageDiggByMonth);

			Console.WriteLine();
        }

        public void SetCreatedCountByMonth()
        {
            IEnumerable<DateTime> createTimes = _context.Videos.AsEnumerable().Select(x =>
            {
                JToken jToken = JsonConvert.DeserializeObject<JToken>(x.JsonString);
                return DateTimeOffset.FromUnixTimeSeconds(jToken.SelectToken("$.createTime").Value<long>()).UtcDateTime;
            });

            foreach (var createTime in createTimes)
            {
                int year = createTime.Year;
                int month = createTime.Month;

                // Create a tuple (Year, Month) as the key
                var key = (Year: year, Month: month);

                // Increment count for the key if it exists, otherwise add a new entry with count 1
                if (CreatedCountByMonth.ContainsKey(key))
                {
                    CreatedCountByMonth[key]++;
                }
                else
                {
                    CreatedCountByMonth.Add(key, 1);
                }
            }
        }

        public IEnumerable<(int DiggCount, int PlayCount)> SetDiggPlayList()
        {
            return _context.Videos.AsEnumerable().Select(x =>
            {
                JToken jToken = JsonConvert.DeserializeObject<JToken>(x.JsonString);
                int playCount = int.Parse(jToken.SelectToken("$.statsV2.playCount").Value<string>());
                int diggCount = int.Parse(jToken.SelectToken("$.statsV2.diggCount").Value<string>());
                return (DiggCount: diggCount, PlayCount: playCount);
            });
        }

        public void SetDurationCategory()
        {
            foreach (var video in _context.Videos.AsEnumerable())
            {
				JToken jToken = JsonConvert.DeserializeObject<JToken>(video.JsonString);
				int duration = jToken.SelectToken("$.video.duration").Value<int>();
				if (duration < 15)
				{
					IncrementDurationCount("Less than 15s");
				}
				else if (duration >= 15 && duration < 30)
				{
					IncrementDurationCount("15s to less than 30s");
				}
				else if (duration >= 30 && duration < 45)
				{
					IncrementDurationCount("30s to less than 45s");
				}
				else if (duration >= 45 && duration < 60)
				{
					IncrementDurationCount("45s to less than 60s");
				}
				else
				{
					IncrementDurationCount("60s and above");
				}

			}
        }

		private void IncrementDurationCount(string category)
		{
			if (DurationCategoryCount.ContainsKey(category))
			{
				DurationCategoryCount[category]++;
			}
			else
			{
				DurationCategoryCount[category] = 1;
			}
		}

        public void SetAveragePlayByMonth(string attr, SortedDictionary<(int Year, int Month), double> averageCountByMonth)
        {
			IEnumerable<(DateTime, int)> countByTime = _context.Videos.AsEnumerable().Select(x =>
			{
				JToken jToken = JsonConvert.DeserializeObject<JToken>(x.JsonString);
                DateTime createTimes = DateTimeOffset.FromUnixTimeSeconds(jToken.SelectToken("$.createTime").Value<long>()).UtcDateTime;
                int count = int.Parse(jToken.SelectToken($"$.statsV2.{attr}").Value<string>());
                return (createTimes, count);
			});

			foreach (var item in countByTime)
			{
                int year = item.Item1.Year;
				int month = item.Item1.Month;
                int count = item.Item2;

				// Create a tuple (Year, Month) as the key
				var key = (Year: year, Month: month);

				// Increment count for the key if it exists, otherwise add a new entry with count 1
				if (averageCountByMonth.ContainsKey(key))
				{
					averageCountByMonth[key] += count;
				}
				else
				{
					averageCountByMonth.Add(key, count);
				}

            }

			foreach (var dateKey in CreatedCountByMonth.Keys)
			{
				averageCountByMonth[dateKey] /= CreatedCountByMonth[dateKey];
			}
		}


		public SortedDictionary<(int Year, int Month), int> CreatedCountByMonth { get; set; } = new SortedDictionary<(int Year, int Month), int>();
        public IEnumerable<(int DiggCount, int PlayCount)> DiggPlayList { get; set; }
        public Dictionary<string, int> DurationCategoryCount { get; set; } = new Dictionary<string, int>();
        public SortedDictionary<(int Year, int Month), double> AveragePlayByMonth { get; set; } = new SortedDictionary<(int Year, int Month), double>();
        public SortedDictionary<(int Year, int Month), double> AverageDiggByMonth { get; set; } = new SortedDictionary<(int Year, int Month), double>();


    }

}
