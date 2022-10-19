using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using GetAPISunset.Data;

namespace GetAPISunset
{
    class Program
    {
        public static async Task<Root> GetWebApiLongLatAsync()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("https://api.sunrise-sunset.org/json?lat=36.7201600&lng=-4.4203400&date=2022-10-13");
            response.EnsureSuccessStatusCode();

            Root wd = await response.Content.ReadFromJsonAsync<Root>();

            return wd;
        }

        static async Task Main(string[] args)
        {
            var result = await GetWebApiLongLatAsync();

            Console.WriteLine($"Sunset: {result.results.sunset}");
            Console.WriteLine($"Sunrise: {result.results.sunrise}");

            var db = new ApplicationDbContext();
            var colors = new Results[]
            {
                new Results(){sunrise = "15", sunset = "28"},
                new Results(){sunrise = "10", sunset = "20"},
                new Results(){sunrise = "70", sunset = "90"}
            };
            db.SunTime.AddRange(colors);
            db.SaveChanges();
        }
    }
}
    


