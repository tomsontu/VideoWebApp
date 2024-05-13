using System;
using System.Collections.Generic;
using System.Text;
using StackExchange.Redis;

namespace Videos.Database
{
    public class RedisDb
    {
        private readonly ConnectionMultiplexer redis;

        public RedisDb()
        {
            redis = ConnectionMultiplexer.Connect("localhost");
        }

        public IDatabase GetDatabase()
        {
            return redis.GetDatabase();
        }
    }
}
