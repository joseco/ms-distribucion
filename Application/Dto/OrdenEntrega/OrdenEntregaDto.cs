using Application.Dto.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.OrdenEntrega
{
    public class OrdenEntregaDto
    {
        public DateTime FechaRegistro { set; get; }
        public DateTime? FechaConsolidacion { get; private set; }
        public DateTime? FechaFinalizacion { get; private set; }
        public DateTime? FechaAnulacion { get; private set; }
        public string Destinatario { get; set; }
        public string Direccion { set; get; }
        public string Telefono { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public string Estado { set; get; }

        public ICollection<ItemDto> Items { get; set; }


    }
}
