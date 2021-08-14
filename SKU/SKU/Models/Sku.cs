using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SKU.Models
{
    public class Sku
    {

        public string id_sku { get; set; }
        public string descripcion { get; set; }
        public int existencia { get; set; }
        public bool estado { get; set; }

    }
}
