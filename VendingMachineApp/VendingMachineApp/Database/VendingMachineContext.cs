using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VendingMachineApp.Models;

namespace VendingMachineApp.Database
{
    public class VendingMachineContext:DbContext
    {
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Operator> Operators { get; set; }
    }
}