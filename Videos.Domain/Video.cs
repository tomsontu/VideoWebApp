using System;
using System.Collections.Generic;
using System.Text;

namespace Videos.Database
{
    public class Video
    {
        public int Id { get; set; }
        public string VideoId { get; set; }
        public string JsonString { get; set; }
        public string Remark { get; set; }
    }
}
