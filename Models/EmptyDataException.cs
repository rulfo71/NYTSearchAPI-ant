using System;

namespace NYTWebApi.Models
{
    public class EmptyDataException : Exception
    {
        
        public string Text { get; set; }
        public EmptyDataException()
        {
            Text = "You must complete all fields";
        }
    }
}