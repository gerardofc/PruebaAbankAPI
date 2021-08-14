using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SKU.Models
{
    public class OrdenDetalle
    {
        public int id_orden { get; set; }
        public string id_sku { get; set; }
        public int cantidad { get; set; }
        public bool estado { get; set; }
        public DateTime fecha_ingreso { get; set; }
    }
}
