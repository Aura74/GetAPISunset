using System;
using System.Net.Http;
using System.Threading.Channels;
using System.Threading.Tasks;


namespace GetAPISunset
{
    class Program
    {
        public static async Task<string> GetWebApiLongLatAsync()
        {
        var uri = $"https://api.sunrise-sunset.org/json?lat=36.7201600&lng=-4.4203400&date=2022-10-13";
        var httpClient = new HttpClient();

        HttpResponseMessage response = await httpClient.GetAsync(uri);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();

        return result;
        }

        static async Task Main(string[] args)
        {
            var result = await GetWebApiLongLatAsync();


            Console.WriteLine(result);
        }

        UppNer uppner = new UppNer();
    }
}
    


