using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public enum EstadoOrdenEntrega
    {
        Pendiente = 1,
        ListoParaEntregar = 2,
        EnProgreso = 3,
        Finalizado = 4,
        Anulado = 5
    }
}
