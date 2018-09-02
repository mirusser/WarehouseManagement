using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WarehouseManagement.Models
{
    public class TypeOfSubassembly
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string Name { get; set; }
    }
}