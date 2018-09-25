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
            if (this.verifyNull())
            {
                //preguntarle a mati que hacer en estos casos
                Console.WriteLine("*********");
                Console.WriteLine("*********");
                Console.WriteLine("*********");
                Console.WriteLine("UEPAAA vino alguno empty!!! guardaaaaa");
                Console.WriteLine("*********");
                Console.WriteLine("*********");
                Console.WriteLine("*********");
            }
            if (this.verifyDates())
            {
                Console.WriteLine("*********");
                Console.WriteLine("*********");
                Console.WriteLine("*********");
                Console.WriteLine("End date es mayor que begin!");
                Console.WriteLine("*********");
                Console.WriteLine("*********");
                Console.WriteLine("*********");
            }

        }

        private bool verifyDates()
        {
            int begin_dateInt;
            int end_dateInt;
            Int32.TryParse(this.Begin_date,out begin_dateInt);
            Int32.TryParse(this.End_date,out end_dateInt);
            return (begin_dateInt > end_dateInt);
        }

        private bool verifyNull()
        {
            return (string.IsNullOrEmpty(Theme) || string.IsNullOrEmpty(Begin_date) || string.IsNullOrEmpty(End_date));
        }
    }
}