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
        public static async Task<Root> GetWebApiLongLatAsync( int y, int m, int d)
        {
            HttpClient httpClient = new HttpClient();

            // 2022-10-13

            var SunDate = new DateOnly(y,m,d);
            //Console.WriteLine(SunDate);
            
            var addDays = SunDate.AddDays(1);
            Console.WriteLine(addDays);

            HttpResponseMessage response = await httpClient.GetAsync($"https://api.sunrise-sunset.org/json?lat=36.7201600&lng=-4.4203400&date={SunDate}");
            response.EnsureSuccessStatusCode();

            Root wd = await response.Content.ReadFromJsonAsync<Root>();

            return wd;
        }

        static async Task Main(string[] args)
        {
            //for (int i = 0; i < 4; i++)
            //{
                var result = await GetWebApiLongLatAsync(2012, 12, 12);

                Console.WriteLine($"Sunset: {result.results.sunset}");
                Console.WriteLine($"Sunrise: {result.results.sunrise}");

                var db = new ApplicationDbContext();
                var colors = new Results[]
                {
                    new Results(){sunrise = $"{result.results.sunrise}", sunset = $"{result.results.sunset}"},
                };
                db.SunTime.AddRange(colors);
                db.SaveChanges();

            //}
            
            
        }
    }
}
    


