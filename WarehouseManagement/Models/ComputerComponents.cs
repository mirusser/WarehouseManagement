using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WarehouseManagement.Models
{
    public class ComputerComponents
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int CatalogNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string Name { get; set; }

        public int TypeOfSubassemblyId { get; set; }
        [ForeignKey("TypeOfSubassemblyId")]
        public virtual TypeOfSubassembly TypeOfSubassembly { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Model { get; set; }

        public int Barcode { get; set; }


    }
}