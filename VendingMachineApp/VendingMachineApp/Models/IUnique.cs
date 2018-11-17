using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendingMachineApp.Models
{
    public interface IUnique
    {
        string SeriesNumber { get; set; }
    }
}