using System;
using System.Collections.Generic;

namespace NYTWebApi.Models
{
    public class ExceptionsList
    {
        public string Messages { get; set; }
        public List<Exception> listOfExceptions { get; set; }
        public ExceptionsList()
        {
            listOfExceptions = new List<Exception>();
        }

        public void PrepareMessage()
        {
            foreach (var exception in listOfExceptions)
            {
                this.Messages += exception.Message;
            }
        }
        public bool HasEmptyDataException()
        {
            foreach (var exception in this.listOfExceptions)
            {
                if (exception.GetType().Name == "EmptyDataException")
                {
                    return true;
                }
            }
            return false;
        }
        public bool HasWrongDatesException()
        {
            foreach (var exception in this.listOfExceptions)
            {
                if (exception.GetType().Name == "WrongDatesException")
                {
                    return true;
                }
            }
            return false;
        }
    }
}