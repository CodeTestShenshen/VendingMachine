using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendingMachineApp.ViewModels
{
    
    public class RunningState
    {
        public string MachineSeriesNumber { get; set; }
        
        /// <summary>
        /// all flavours in the machine and their number stored
        /// </summary>
        public Dictionary<string, int> FlavourCategories { get; set; }

        /// <summary>
        /// key is type of money represented with cents, value is the number of this type of money left
        /// </summary>
        public Dictionary<int, int> CashStatus { get; set; }

        public int EftopsInCents { get; set; }
    }
}