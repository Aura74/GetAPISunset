﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetAPISunset
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Results
    {
        public int Id { get; set; }
        public string? sunrise { get; set; }
        public string? sunset { get; set; }
        //public DateTime? sunrise { get; set; }
        //public DateTime? sunset { get; set; }
        //public DateTime solar_noon { get; set; }
        //public int day_length { get; set; }
        //public DateTime civil_twilight_begin { get; set; }
        //public DateTime civil_twilight_end { get; set; }
        //public DateTime nautical_twilight_begin { get; set; }
        //public DateTime nautical_twilight_end { get; set; }
        //public DateTime astronomical_twilight_begin { get; set; }
        //public DateTime astronomical_twilight_end { get; set; }
    }
}





