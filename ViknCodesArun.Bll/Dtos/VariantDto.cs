using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViknCodesArun.Bll.Dtos
{
    public class VariantDto
    {
        public string Name { get; set; }
        public List<SubVariantDto> SubVariants { get; set; } = new();
    }

}
