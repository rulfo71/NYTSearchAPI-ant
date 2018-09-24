using System;
using System.Collections.Generic;

namespace NYTWebApi.Models
{
    public class Doc
    {
        public string web_url { get; set; }
        public string snippet { get; set; }
        public Headline headline { get; set; }
        public DateTime pub_date { get; set; }
        public double score { get; set; }
    }
}