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
                throw new EmptyDataException();

            }
            if (this.verifyDates())
            {
                throw new WrongDatesException();

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