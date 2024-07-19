using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.common
{
    public class StackOverflowPost
    {
        public List<string> Tags { get; set; }
        public Owner Owner { get; set; }
        public bool Is_answered { get; set; }
        public int View_count { get; set; }
        public int Answer_count { get; set; }
        public int Score { get; set; }
        public int Last_activity_date { get; set; }
        public int Creation_date { get; set; }
        public int Question_id { get; set; }
        public string Content_license { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
    }

}
