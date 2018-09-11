namespace NYTWebApi.Models
{
    public class SearchQuery
    {
        public string Theme{get;set;}
        public string Begin_date{get;set;}
        public string End_date{get;set;}

        public SearchQuery(string theme, string begin_date, string end_date){
            Theme = theme; 
            Begin_date = begin_date;
            End_date = end_date;
        }
    }
}