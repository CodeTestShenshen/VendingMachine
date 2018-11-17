using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VendingMachineApp.Models
{
    public class Transaction : BaseModel, IActive
    {
        public Machine Machine { get; set; }
        public int MachineId { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}