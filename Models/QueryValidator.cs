using System;
using System.Collections.Generic;

namespace NYTWebApi.Models
{
    public class QueryValidator
    {
        ExceptionsList listOfExceptions ; 
        public QueryValidator()
        {
            listOfExceptions = new ExceptionsList();
        }

        public ExceptionsList validateData(string theme, string begin_date, string end_date)
        {
            if (this.verifyNull(theme,begin_date,end_date))
            {
                // throw new EmptyDataException();
                this.listOfExceptions.listOfExceptions.Add(new EmptyDataException());
            }
            if (this.verifyDates(theme, begin_date, end_date))
            {
                // throw new WrongDatesException();
                this.listOfExceptions.listOfExceptions.Add(new WrongDatesException());
            }

            return this.listOfExceptions;

        }

        private bool verifyDates(string theme, string begin_date, string end_date)
        {
            int begin_dateInt;
            int end_dateInt;
            Int32.TryParse(begin_date,out begin_dateInt);
            Int32.TryParse(end_date,out end_dateInt);
            return (begin_dateInt > end_dateInt);
        }

        private bool verifyNull(string theme, string begin_date, string end_date)
        {
            return (string.IsNullOrEmpty(theme) || string.IsNullOrEmpty(begin_date) || string.IsNullOrEmpty(end_date));
        }
    }
}