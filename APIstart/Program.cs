using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIstart
{
    class Program
    {
        static void Main(string[] args)
        {
            var kanyeURL = " https://api.kanye.rest ";
            var client = new HttpClient();
            var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
            Console.WriteLine(kanyeQuote);

            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var ronResponse = client.GetStringAsync(ronURL).Result;
            var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[',' ').Replace(']',' ').Trim();
            Console.WriteLine(ronQuote);
            int convoCounter = 0;
           
            while (convoCounter<5)
            {
                 kanyeResponse = client.GetStringAsync(kanyeURL).Result;
                 kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

                 ronResponse = client.GetStringAsync(ronURL).Result;
                 ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();



                Console.WriteLine("Kanye says: " + kanyeQuote);
                Console.WriteLine("Ron says: " + ronQuote);
                



                convoCounter++;

            }
            
    




        }


        
        
    }
}
