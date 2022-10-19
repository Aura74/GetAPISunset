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
        public static async Task<Root> GetWebApiLongLatAsync(string SunDate)
        {
            HttpClient httpClient = new HttpClient();

            // 2022-10-13 // ska vara detta format

            // convert 
            string dt = "2010-10-04T20:12:45-5:00";
            DateTime newDt = DateTime.Parse(dt);
            //Console.WriteLine(newDt.ToString());

            //int vadSrevDu = Convert.ToInt32(Console.ReadLine());
            int dayCount = 3;
            //int dayCount = vadSrevDu;
            //Console.WriteLine($"Du skrev {dayCount}");

            DateTime today = DateTime.Today;
            string requestStartDate = today.AddDays(-dayCount).ToString("yyyy-MM-dd");
            string requestEndDate = today.AddDays(-dayCount + 2).ToString("yyyy-MM-dd");

            //Time cory
            DateOnly dateOnly = DateOnly.FromDateTime(DateTime.Now);
            TimeOnly timeOnly = TimeOnly.FromDateTime(DateTime.Now);
            //Console.WriteLine($"DateOnly {dateOnly}");
            //Console.WriteLine($"TimeOnly {timeOnly}");

            //SunDate = requestStartDate;
            //var SunDate = new DateOnly(y,m,d);
            //Console.WriteLine(SunDate);

            //var addDays = SunDate.AddDays(1);
            //Console.WriteLine(addDays);

            var toDayString = DateTime.Now.ToShortDateString();
            //Console.WriteLine(toDayString);

            var language = System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            var uri = $"https://api.sunrise-sunset.org/json?lat=36.7201600&lng=-4.4203400&date={SunDate}";
            //var uri2 = $"https://api.sunrise-sunset.org/json?lat=36.7201600&lng=-4.4203400&date=today"; // idag
            var uri3 = $"https://api.sunrise-sunset.org/json?lat=36.7201600&lng=-4.4203400&formatted=0"; // dagens datum "sunrise":"2022-10-19T05:05:35+00:00",

            HttpResponseMessage response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            Root wd = await response.Content.ReadFromJsonAsync<Root>();
            return wd;
        }

        //public static string GetSunrise()
        //{
        //    HttpClient client = new HttpClient();
        //    var responce = client.GetStringAsync("https://api.sunrise-sunset.org/json?lat=36.7201600&lng=-4.4203400").Result;
        //    var Sunrise = JsonSerializer.Deserialize<SunriseSunsetDto>(responce.ToString()).Results.sunrise;
        //    return Sunrise;
        //}
        //public static string GetSunset()
        //{
        //    HttpClient client = new HttpClient();
        //    var responce = client.GetStringAsync("https://api.sunrise-sunset.org/json?lat=36.7201600&lng=-4.4203400").Result;
        //    var Sunset = JsonSerializer.Deserialize<SunriseSunsetDto>(responce.ToString()).Results.sunset;
        //    return Sunset;
        //}


        static async Task Main(string[] args)
        {
            //for (int i = 0; i < 4; i++)
            //{
            //var result = await GetWebApiLongLatAsync(2012, 8, 12);

            DateOnly wert = DateOnly.FromDateTime(DateTime.Now);
            for (int i = 0; i < 5; i++)
            {
                wert = wert.AddDays(1);
                Console.WriteLine(wert);


                var result = await GetWebApiLongLatAsync(wert.ToString());

            Console.WriteLine($"Sunset: {result.results.sunset}");
            Console.WriteLine($"Sunrise: {result.results.sunrise}");


            var db = new ApplicationDbContext();
            var sunUpOrDownTime = new Results[]
            {
                    new Results(){sunrise = $"{result.results.sunrise}", sunset = $"{result.results.sunset}"},
            };
            db.SunTime.AddRange(sunUpOrDownTime);
            db.SaveChanges();

            //}



                //DateOnly dateOnly = DateOnly.FromDateTime(DateTime.Now).AddDays(1);
            }//wert
        }
    }
}
    


