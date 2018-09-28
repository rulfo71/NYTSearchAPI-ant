namespace NYTWebApi.Models
{
    public class Headline
    {
        public string main { get; set; }
        public string kicker { get; set; }
        public string content_kicker { get; set; }
        public string print_headline { get; set; }
        public object name { get; set; }
        public object seo { get; set; }
        public object sub { get; set; }

        public Headline(string main, string kicker, string content_kicker, object name, object seo, object sub){
            this.main = main; 
            this.kicker = kicker;
            this.content_kicker = content_kicker;
            this.name = name;
            this.seo = seo;
            this.sub = sub;
        }
    }
}