using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViknCodesArun.Bll.Dtos
{
    public class SubVariantDto
    {
        public List<string> Option { get; set; } = new();
        public decimal Stock { get; set; }
    }

}
