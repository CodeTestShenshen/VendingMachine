using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VendingMachineApp.Models
{
    public enum States { NSW = 1, WA, VIC, QLD}
    public class Machine : BaseModel, IActive, IUnique
    {
        [Required]
        [StringLength(100)]
        [Index(IsUnique = true)]
        public string SeriesNumber { get; set; } 
        [StringLength (200)]
        [Required]
        public string Location { get; set; }
        [StringLength(4)]
        [Required]
        public string PostCode { get; set; }
        [Required]
        public States State { get; set; }
        [Required]
        public bool IsActive { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
        } 
}