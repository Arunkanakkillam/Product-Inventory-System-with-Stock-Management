
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ViknCodesArun.Dll.Models
{
    public class Product:Auditable
    {
        public Guid Id { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public Guid? CreatedUserId { get; set; }
        public string? ProductImage { get; set; }
        public bool? IsFavourite { get; set; }
        public bool? Active { get; set; }
        [StringLength(100)]
        public string? HSNCode { get; set; }
        public decimal TotalStock {  get; set; }
        public ICollection<Variants> Variants { get; set; }

    }
}
