using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Function
{
    public class ODimension01    {
        [JsonProperty("value")]
        public object Value { get; set; } 

        [JsonProperty("surcharge")]
        public int Surcharge { get; set; } 

        [JsonProperty("surcharge1")]
        public int Surcharge1 { get; set; } 

        [JsonProperty("surcharge2")]
        public int Surcharge2 { get; set; } 

        [JsonProperty("value1")]
        public int Value1 { get; set; } 

        [JsonProperty("value2")]
        public int Value2 { get; set; } 

        [JsonProperty("count")]
        public string Count { get; set; } 
    }

    public class ODimension02    {
        [JsonProperty("value")]
        public object Value { get; set; } 

        [JsonProperty("surcharge")]
        public int Surcharge { get; set; } 

        [JsonProperty("surcharge1")]
        public int Surcharge1 { get; set; } 

        [JsonProperty("surcharge2")]
        public int Surcharge2 { get; set; } 

        [JsonProperty("value1")]
        public int Value1 { get; set; } 

        [JsonProperty("value2")]
        public int Value2 { get; set; } 

        [JsonProperty("count")]
        public string Count { get; set; } 
    }

    public class LkRadius    {
        [JsonProperty("value")]
        public object Value { get; set; } 

        [JsonProperty("surcharge")]
        public int Surcharge { get; set; } 

        [JsonProperty("surcharge1")]
        public int Surcharge1 { get; set; } 

        [JsonProperty("surcharge2")]
        public int Surcharge2 { get; set; } 

        [JsonProperty("value1")]
        public int Value1 { get; set; } 

        [JsonProperty("value2")]
        public int Value2 { get; set; } 

        [JsonProperty("count")]
        public string Count { get; set; } 
    }

    public class LkLochradius    {
        [JsonProperty("value")]
        public object Value { get; set; } 

        [JsonProperty("surcharge")]
        public int Surcharge { get; set; } 

        [JsonProperty("surcharge1")]
        public int Surcharge1 { get; set; } 

        [JsonProperty("surcharge2")]
        public int Surcharge2 { get; set; } 

        [JsonProperty("value1")]
        public int Value1 { get; set; } 

        [JsonProperty("value2")]
        public int Value2 { get; set; } 

        [JsonProperty("count")]
        public string Count { get; set; } 
    }

    public class LkWinkel    {
        [JsonProperty("value")]
        public object Value { get; set; } 

        [JsonProperty("surcharge")]
        public int Surcharge { get; set; } 

        [JsonProperty("surcharge1")]
        public int Surcharge1 { get; set; } 

        [JsonProperty("surcharge2")]
        public int Surcharge2 { get; set; } 

        [JsonProperty("value1")]
        public int Value1 { get; set; } 

        [JsonProperty("value2")]
        public int Value2 { get; set; } 

        [JsonProperty("count")]
        public string Count { get; set; } 
    }

    public class LkAnzahl    {
        [JsonProperty("value")]
        public double Value { get; set; } 

        [JsonProperty("surcharge")]
        public int Surcharge { get; set; } 

        [JsonProperty("surcharge1")]
        public int Surcharge1 { get; set; } 

        [JsonProperty("surcharge2")]
        public int Surcharge2 { get; set; } 

        [JsonProperty("value1")]
        public int Value1 { get; set; } 

        [JsonProperty("value2")]
        public int Value2 { get; set; } 

        [JsonProperty("count")]
        public string Count { get; set; } 
    }

    public class Root    {
        [JsonProperty("o_dimension01")]
        public ODimension01 ODimension01 { get; set; } 

        [JsonProperty("o_dimension02")]
        public ODimension02 ODimension02 { get; set; } 

        [JsonProperty("lk_radius")]
        public LkRadius LkRadius { get; set; } 

        [JsonProperty("lk_lochradius")]
        public LkLochradius LkLochradius { get; set; } 

        [JsonProperty("lk_winkel")]
        public LkWinkel LkWinkel { get; set; } 

        [JsonProperty("lk_anzahl")]
        public LkAnzahl LkAnzahl { get; set; } 
    }


    public class FunctionHandler
    {
        public async Task<(int, string)> Handle(HttpRequest request)
        {
            var reader = new StreamReader(request.Body);
            var input = await reader.ReadToEndAsync();
            Root obj = JsonConvert.DeserializeObject<Root>(input); 

            return (200, $"{obj.LkAnzahl.Value *100}");
        }
    }
}