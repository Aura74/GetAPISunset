using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Linq;

namespace GetAPISunset
{
    public class Service
    {
        //HttpClient httpClient = new HttpClient();

        //public async Task<RootSkaHa> GetForecastAsync()
        //{
        //    RootSkaHa forecast = null;

        //    //var uri = $"https://api.sunrise-sunset.org/json?lat=36.7201600&lng=-4.4203400&date=2022-10-13";
        //    forecast = await ReadWebApiAsync(uri);

        //    return forecast;


        //}

        //HttpClient httpClient = new HttpClient();
        //string uri = $"https://api.sunrise-sunset.org/json?lat=36.7201600&lng=-4.4203400&date=2022-10-13";
        //private async Task<RootSkaHa> ReadWebApiAsync(string uri)
        //{
     
        //        HttpResponseMessage response = await httpClient.GetAsync(uri);
        //        response.EnsureSuccessStatusCode();
        //        Root wd = await response.Content.ReadFromJsonAsync<Root>();

        //        RootSkaHa forecast = new RootSkaHa();
        //        forecast.results.sunrise = wd.results.sunrise;
        //        forecast.results.sunset = wd.results.sunset;
                

        //        return forecast;

        //}
    }
}
