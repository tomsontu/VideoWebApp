using System;
using System.Collections.Generic;
using System.Text;

namespace Videos.Domain
{
	public class Review
	{
        public int Id { get; set; }
        public string VideoId { get; set; }
        public string VideoReview { get; set; }
    }
}
