using MinisuperZeus.BC.ReglasDeNegocio;
using MinisuperZeus.BW.Interfaces.BW;
using MinisuperZeus.BW.Interfaces.DA;
using MinisuperZeus.DA.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinisuperZeus.BW.CU
{
    public class GestionarListaDeDeseosBW : IGestionarListaDeDeseosBW
    {
        private readonly IGestionarListaDeDeseosDA gestionarListaDeDeseosDA;

        public GestionarListaDeDeseosBW(IGestionarListaDeDeseosDA gestionarListaDeDeseosDA)
        {
            this.gestionarListaDeDeseosDA = gestionarListaDeDeseosDA;
        }

        public async Task<bool> AgregarALaLista(int idProducto)
        {
            bool validacion = ValidacionProductos.IdEsValido(idProducto);

            if (!validacion)
            {
                return false;
            }

            return await this.gestionarListaDeDeseosDA.AgregarALaLista(idProducto);
        }

        public async Task<bool> AgregarCantidadProducto(int idProducto, int cantidad)
        {
            bool validacion = ValidacionProductos.IdEsValido(idProducto) 
                && ValidacionProductos.CantidadMayorACero(cantidad);

            if (!validacion)
            {
                return false;
            }

            return await this.gestionarListaDeDeseosDA.AgregarCantidadProducto(idProducto, cantidad);
        }

        public async Task<bool> EliminarCantidadProducto(int idProducto, int cantidad)
        {
            bool validacion = ValidacionProductos.IdEsValido(idProducto)
                && ValidacionProductos.CantidadMayorACero(cantidad);

            if (!validacion)
            {
                return false;
            }

            return await this.gestionarListaDeDeseosDA.EliminarCantidadProducto(idProducto, cantidad);
        }

        public async Task<bool> EliminarDeLaLista(int idProducto)
        {
            bool validacion = ValidacionProductos.IdEsValido(idProducto);

            if (!validacion)
            {
                return false;
            }

            return await this.gestionarListaDeDeseosDA.EliminarDeLaLista(idProducto);
        }

        public async Task<IEnumerable<Deseo>> GetListaDeDeseos()
        {
            return await this.gestionarListaDeDeseosDA.GetListaDeDeseos();
        }

        public async Task<decimal> TotalAPagarConIVA(decimal impuesto)
        {
            return await this.gestionarListaDeDeseosDA.TotalAPagarConIVA(impuesto);
        }
    }
}
