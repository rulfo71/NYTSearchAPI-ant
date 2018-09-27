using System;

namespace NYTWebApi.Models
{
    public class WrongDatesException : Exception
    {
        public string Text { get; set; }
        public WrongDatesException()
        {
            Text = "End Date must be later than begin date";
        }
    }
}