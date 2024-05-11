using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Videos.Database;

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
            Console.WriteLine();
        }


        public SortedDictionary<(int Year, int Month), int> CreatedCountByMonth { get; set; } = new SortedDictionary<(int Year, int Month), int>();


    }

}
