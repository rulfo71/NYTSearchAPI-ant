using System.Collections.Generic;
namespace NYTWebApi.Models
{
    public class Response
    {
        public IEnumerable<Doc> docs { get; set; }
        public Meta meta { get; set; }

    }
}