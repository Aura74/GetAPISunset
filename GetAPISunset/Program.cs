using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Channels;
using System.Threading.Tasks;



namespace GetAPISunset
{
    class Program
    {
       // public static async Task<string> GetWebApiLongLatAsync()
        public static async Task<ResultsSkaHa> GetWebApiLongLatAsync()
        {
        
            HttpClient httpClient = new HttpClient();

             HttpResponseMessage response = await httpClient.GetAsync("https://api.sunrise-sunset.org/json?lat=36.7201600&lng=-4.4203400&date=2022-10-13");
            response.EnsureSuccessStatusCode();
            //var result = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();

            Results wd = await response.Content.ReadFromJsonAsync<Results>();

            ResultsSkaHa ff = new ResultsSkaHa();
            ff.sunrise = wd.sunrise;
            ff.sunset = wd.sunset;



            return ff;




        }

        static async Task Main(string[] args)
        {
            var result = await GetWebApiLongLatAsync();


            Console.WriteLine($"Sunset: {result.sunset}");
            Console.WriteLine($"Sunrise: {result.sunrise}");
        }

        UppNer uppner = new UppNer();
    }
}
    


