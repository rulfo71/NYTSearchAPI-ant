using System;

namespace NYTWebApi.Models
{
    public class QueryValidator
    {
        public String Theme { get; set; }
        public String Begin_date { get; set; }
        public String End_date { get; set; }

        public QueryValidator(string theme, string begin_date, string end_date)
        {
            Theme = theme;
            Begin_date = begin_date;
            End_date = end_date;
        }

        public void validateData()
        {
            if (this.anyNull())
            {
                Console.WriteLine("UEPAAA vino alguno empty!!! guardaaaaa");
            }
        }

        private Boolean anyNull()
        {
            if (string.IsNullOrEmpty(Theme) || string.IsNullOrEmpty(Begin_date) || string.IsNullOrEmpty(End_date))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}