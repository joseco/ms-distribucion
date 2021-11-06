using CoreDDD.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Rules
{
    public class ChangeOrderStatusRule : IBusinessRule
    {
        private readonly EstadoOrdenEntrega estadoActual;
        private readonly EstadoOrdenEntrega estadoNuevo;

        public ChangeOrderStatusRule(EstadoOrdenEntrega estadoActual, EstadoOrdenEntrega estadoNuevo)
        {
            this.estadoActual = estadoActual;
            this.estadoNuevo = estadoNuevo;
        }

        public string Message => $"No se puede cambiar del estado { estadoActual } al estado { estadoNuevo }";

        public bool IsBroken()
        {
            if(estadoNuevo == EstadoOrdenEntrega.ListoParaEntregar && estadoActual != EstadoOrdenEntrega.Pendiente)
            {
                return true;
            }

            if(estadoNuevo == EstadoOrdenEntrega.Pendiente && estadoActual != EstadoOrdenEntrega.ListoParaEntregar)
            {
                return true;
            }

            if (estadoNuevo == EstadoOrdenEntrega.EnProgreso && estadoActual != EstadoOrdenEntrega.ListoParaEntregar)
            {
                return true;
            }

            if (estadoNuevo == EstadoOrdenEntrega.Finalizado && estadoActual != EstadoOrdenEntrega.EnProgreso)
            {
                return true;
            }

            if(estadoNuevo == EstadoOrdenEntrega.Anulado && (
                estadoNuevo != EstadoOrdenEntrega.Pendiente || estadoNuevo != EstadoOrdenEntrega.EnProgreso || estadoNuevo != EstadoOrdenEntrega.ListoParaEntregar))
            {
                return true;
            }

            return false;
        }
    }
}
