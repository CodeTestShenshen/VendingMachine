using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VendingMachineApp.Models
{
    public enum  TransactionType { cash = 1, eftops =2}

    public class Transaction : BaseModel, IActive
    {
       
        public Machine Machine { get; set; }
        [Required]
        public int MachineId { get; set; }
        
        public Flaviour Flaviour { get; set; }

        [Required]
        public int FlaviourId { get; set; }

        [Required]
        public TransactionType TransactionType { get; set; }

        [Required]
        public int PriceInCents { get; set; }

        [Required]
        public DateTime TansactionTime { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}