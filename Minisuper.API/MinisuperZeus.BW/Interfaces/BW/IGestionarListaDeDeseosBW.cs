using MinisuperZeus.BC.Modelos;
using MinisuperZeus.DA.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinisuperZeus.BW.Interfaces.BW
{
    public interface IGestionarListaDeDeseosBW
    {
        public Task<IEnumerable<Deseo>> GetListaDeDeseos();

        public Task<bool> AgregarALaLista(int idProducto);

        public Task<bool> EliminarDeLaLista(int idProducto);

        public Task<decimal> TotalAPagarConIVA(decimal impuesto);

        public Task<bool> AgregarCantidadProducto(int idProducto, int cantidad);

        public Task<bool> EliminarCantidadProducto(int idProducto, int cantidad);

    }
}