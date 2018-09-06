using System;
using System.Collections.Generic;

namespace NYTWebApi.Models
{
    public class article
    {

    }
    public class Headline
    {
        public string main { get; set; }
        public string kicker { get; set; }
        public string content_kicker { get; set; }
        public string print_headline { get; set; }
        public object name { get; set; }
        public object seo { get; set; }
        public object sub { get; set; }
    }

    public class Doc
    {
        public string web_url { get; set; }
        public string snippet { get; set; }
        public Headline headline { get; set; }
        public DateTime pub_date { get; set; }
        public double score { get; set; }
    }

    public class Meta
    {
        public int hits { get; set; }
        public int offset { get; set; }
        public int time { get; set; }
    }

    public class Response
    {
        public List<Doc> docs { get; set; }
        public Meta meta { get; set; }
    }

    public class RootObject
    {
        public string status { get; set; }
        public string copyright { get; set; }
        public Response response { get; set; }
    }
}