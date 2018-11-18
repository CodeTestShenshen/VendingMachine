using Newtonsoft.Json;
using VendingMachineApp.Models;

namespace VendingMachineApp.ViewModels
{
    public class FlavourModel
    {
        [JsonProperty("seriesNumber")]
        public string SeriesNumber { get; set; }

        [JsonProperty("priceInCents")]
        public int PriceInCents { get; set; }

        [JsonProperty("nName")]
        public string Name { get; set; }

        public static FlavourModel Create(Flavour f)
        {
            if (f == null)
                return null;

            return new FlavourModel()
            {
                SeriesNumber = f.SeriesNumber,
                PriceInCents = f.PriceInCents,
                Name = f.Name
            };
        }
         
    }
}