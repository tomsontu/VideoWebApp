using Nest;
using Stripe.Tax;
using System;
using System.Collections.Generic;
using System.Text;

namespace Videos.Database
{
	public class ElasticSearchDb
	{
		private readonly ConnectionSettings settings;

        public ElasticSearchDb()
        {
			settings = new ConnectionSettings(new Uri("http://localhost:9200"))
						.DefaultIndex("videos");
		}

		public ElasticClient GetClient()
		{
			var client = new ElasticClient(settings);
			return client;
		}
	}
}
