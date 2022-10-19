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
        public static async Task<Root> GetWebApiLongLatAsync(string SunDate) // 2022-10-13 // ska vara detta datum-format
        {
            HttpClient httpClient = new HttpClient();

            var latitude = 36.7201600;
            var longitude = -4.4203400;
            var uri = $"https://api.sunrise-sunset.org/json?lat={latitude}&lng={longitude}&date={SunDate}";

            HttpResponseMessage response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            Root wd = await response.Content.ReadFromJsonAsync<Root>();
            return wd;
        }

        static async Task Main(string[] args)
        {
            //var result = await GetWebApiLongLatAsync(2012, 8, 12);
            
            var dateOnly = new DateOnly(2022, 1, 1);
            //DateOnly wert = dateOnly;
            DateOnly wert = DateOnly.FromDateTime(DateTime.Now);
            for (int i = 0; i < 5; i++)
            {
                wert = wert.AddDays(1);
                Console.WriteLine();
                Console.WriteLine(wert);
                var result = await GetWebApiLongLatAsync(wert.ToString());

                Console.WriteLine($"Sunset: {result.results.sunset}");
                Console.WriteLine($"Sunrise: {result.results.sunrise}");
                
                var db = new ApplicationDbContext();
                var sunUpOrDownTime = new Results[]
                {
                        new Results(){sunrise = $"{result.results.sunrise}", sunset = $"{result.results.sunset}", DagenDetGaller = wert.ToString()},
                };
                db.SunTime.AddRange(sunUpOrDownTime);
                db.SaveChanges();
            }//wert
        }
    }
}