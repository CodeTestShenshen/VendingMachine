using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendingMachineApp.ViewModels
{
    public class Cash
    {
        public Cash(int valueInCents)
        {
            this.ValueInCents = valueInCents;
        }
        public int ValueInCents { get; protected set;} 
    }
}