using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendingMachineApp.Models;

namespace VendingMachineApp.ViewModels
{
    public class TransactionModel
    {
        [JsonProperty("machineSeriesNumber")]
        public string MachineSeriesNumber { get; set; }

        [JsonProperty("flavourSeriesNumber")]
        public string FlavourSeriesNumber { get; set; }

        [JsonProperty("machineId")]
        public TransactionType TransactionType { get; set; }

        [JsonProperty("priceInCents")]
        public int PriceInCents { get; set; }

        [JsonProperty("tansactionTime")]
        public DateTime TansactionTime { get; set; }

        [JsonProperty("flavourName")]
        public string FlavourName { get; set; }

        public static TransactionModel Create(Transaction t)
        {
            if (t == null)
                return null;

            return new TransactionModel()
            {   
                MachineSeriesNumber = t.Machine?.SeriesNumber,
                FlavourSeriesNumber = t.Flavour?.SeriesNumber,
                TransactionType = t.TransactionType,
                PriceInCents = t.PriceInCents,
                TansactionTime = t.TansactionTime,
                FlavourName = t.Flavour?.Name
            };
        }

        public static Transaction Create(TransactionModel t, int machineId, int flavourId)
        {
            if (t == null)
                return null;

            return new Transaction()
            {
                MachineId = machineId,
                FlavourId = flavourId,
                TransactionType = t.TransactionType,
                PriceInCents = t.PriceInCents,
                TansactionTime = t.TansactionTime 
            };
        }


    }
}