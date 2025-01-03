﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViknCodesArun.Dll.Models
{
    public class Variants:Auditable
    {
        public int Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public ICollection<SubVariants> SubVariants { get; set; }
        public virtual Product Product { get; set; }

    }
}
