using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using Videos.Database;

namespace Videos.UI.Pages
{
    public class TopicModel : PageModel
    {
        public HashEntry[] HashEntries { get; set; }
        public SortedDictionary<string, object[]> TopicByMonthDict { get; set; } = new SortedDictionary<string, object[]>(); //{"2024/04":[[3.0,4.0],["aaa","bb"]]}
		public SortedDictionary<string, SortedDictionary<double, List<object>>> DateDict { get; private set; }

		private readonly RedisDb _redisDb;
		private readonly ILogger<TopicModel> _logger;

		public TopicModel(RedisDb redisDb, ILogger<TopicModel> logger)
        {
            _redisDb = redisDb;
            _logger = logger;
        }

        public void OnGet()
        {
            SetHashEntry();
			DateDict = GetDateDict("trending_score_videos");
			_logger.LogInformation("A user has viewed the topic page");
		}

        public void SetHashEntry()
        {
            HashEntries = _redisDb.GetDatabase().HashGetAll("topic_by_month");
            foreach (var entry in HashEntries)
            {
                List<double> scoreList = new List<double>();
                List<string> keywordList = new List<string>();
                var result = JsonConvert.DeserializeObject<List<object[]>>(entry.Value.ToString());
                foreach (var item in result)
                {
                    var score = (double)item[0];
                    if (score >= 4)
                    {
						scoreList.Add(score);
						keywordList.Add((string)item[1]);
					}
					
                }
                TopicByMonthDict.Add(entry.Name.ToString(), new object[] { scoreList, keywordList });
            }
            Console.WriteLine();
        }

		public SortedDictionary<string, SortedDictionary<double, List<object>>> GetDateDict(string key)
		{
			var db = _redisDb.GetDatabase();
			var value = db.StringGet(key);

			if (!value.HasValue)
			{
				return null;
			}

			return JsonConvert.DeserializeObject<SortedDictionary<string, SortedDictionary<double, List<object>>>>(value);
		}
	}
}
