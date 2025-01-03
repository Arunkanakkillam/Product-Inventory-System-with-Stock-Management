using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViknCodesArun.Bll.Dtos
{
    public class ProductDto
    {
        public string ProductName { get; set; }
        public Guid CreatedUserId { get; set; }
        public string? ProductImage { get; set; } 
        public bool IsFavourite { get; set; }
        public bool Active { get; set; }
        public string HSNCode { get; set; }
        public decimal TotalStock { get; set; }
        public List<VariantDto> Variants { get; set; } = new();
    }

}
