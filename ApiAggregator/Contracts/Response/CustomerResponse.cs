using ApiAggregator.Models;
using System.Text.Json.Serialization;

namespace ApiAggregator.Contracts.Response
{
    public class CustomerResponse
    {
 
        public Coord Coord { get; set; }

 
        public List<Weather> Weather { get; set; }

 
        public string Base { get; set; }

 
        public Main Main { get; set; }
    }
}
