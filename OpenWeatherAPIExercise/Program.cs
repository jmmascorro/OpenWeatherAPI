using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace OpenWeatherAPIExercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var apiKey = "0c1c49bf7391fcb59e7e2d68bb06cae2";
            while (true)
            {
                Console.WriteLine("Would you like to see information about the weather in your location?");
                var userInput = Console.ReadLine();
                if (userInput.ToLower() == "yes")
                {
                    Console.WriteLine($"Please enter your city name.");
                    var cityName = Console.ReadLine();
                    Console.WriteLine();
                    var weatherURL = $"http://api.openweathermap.org/data/2.5/weather?q={cityName}&units=imperial&appid={apiKey}";

                    var response = client.GetStringAsync(weatherURL).Result;
                    var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
                    Console.WriteLine(formattedResponse);
                    Console.WriteLine();
                    Console.WriteLine("Would you like to choose a different city?");
                    var userResponse = Console.ReadLine();
                    Console.WriteLine();
                    if(userResponse.ToLower() == "no")
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Okay, enjoy your day. Hopfully it doesn't decide to rain " +
                        "and your miles away from an umbrella because you were not prepared...... ");
                }

                
            }
        }
    }
}
