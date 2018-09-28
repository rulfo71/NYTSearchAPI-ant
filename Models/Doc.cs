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

        public Doc(string web_url, string snippet, Headline headline, DateTime pub_date, double score){
            this.web_url = web_url;
            this.snippet = snippet;
            this.headline = headline;
            this.pub_date = pub_date;
            this.score = score;
        }

    }
}