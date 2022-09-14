using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlant.Dto
{
    public class Fuel
    {
        [JsonProperty("gas(euro/MWh)")]
        public decimal GasEuroMWh { get; set; }

        [JsonProperty("kerosine(euro/MWh)")]
        public decimal KerosineEuroMWh { get; set; }

        [JsonProperty("co2(euro/ton)")]
        public decimal Co2EuroTon { get; set; }

        [JsonProperty("wind(%)")]
        public decimal Wind { get; set; }
    }
}
