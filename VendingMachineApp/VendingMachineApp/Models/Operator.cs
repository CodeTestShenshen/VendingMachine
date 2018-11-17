using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VendingMachineApp.Models
{
    public class Operator: BaseModel, IActive
    {
        [StringLength(30)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(30)]
        [Required]
        public string Lastname { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}