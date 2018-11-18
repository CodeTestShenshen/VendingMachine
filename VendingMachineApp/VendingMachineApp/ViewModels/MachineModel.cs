using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendingMachineApp.Models;

namespace VendingMachineApp.ViewModels
{
    public class MachineModel
    {
        [JsonProperty("seriesNumber")]
        public string SeriesNumber { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("postCode")]
        public string PostCode { get; set; }

        [JsonProperty("state")]
        public String State { get; set; }

        public static MachineModel Create(Machine m)
        {
            if (m == null)
                return null;

            return new MachineModel()
            {
                SeriesNumber = m.SeriesNumber,
                Location = m.Location,
                PostCode = m.PostCode,
                State = m.State.ToString()
            };
        }
    }
}