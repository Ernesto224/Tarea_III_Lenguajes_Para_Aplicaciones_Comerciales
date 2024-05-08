using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinisuperZeus.BC.ReglasDeNegocio
{
    public static class ValidacionProductos
    {
        /*
         * se verifica que el id del producto solicitado sea mayor a 0
         */
        public static bool IdEsValido(int id) => (id > 0);

        /*
         * se verifica que una cantidad de producto no sea negativa
         */
        public static bool CantidadMayorACero(int cantidad) => (cantidad > 0);
    }
}
