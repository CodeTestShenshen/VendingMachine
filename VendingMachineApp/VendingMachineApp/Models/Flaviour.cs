using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VendingMachineApp.Models
{
    public class Flaviour : BaseModel, IActive, IUnique
    {
        [Required]
        public string SeriesNumber { get; set; }
        [Required]
        public int PriceInCents { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        public bool IsActive { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}