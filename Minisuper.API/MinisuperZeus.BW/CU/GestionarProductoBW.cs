using MinisuperZeus.BC.Modelos;
using MinisuperZeus.BC.ReglasDeNegocio;
using MinisuperZeus.BW.Interfaces.BW;
using MinisuperZeus.BW.Interfaces.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinisuperZeus.BW.CU
{
    public class GestionarProductoBW : IGestionarProductoBW
    {

        private readonly IGestionarProductoDA gestionarProductoDA;

        public GestionarProductoBW(IGestionarProductoDA gestionarProductoDA)
        {
            this.gestionarProductoDA = gestionarProductoDA;
        }

        public async Task<IEnumerable<Producto>> GetProductos()
        {
            return await this.gestionarProductoDA.GetProductos();
        }

        public Task<Producto> GetProducto(int id)
        {

            bool validacion = ValidacionProductos.IdEsValido(id);

            if (!validacion)
            {
                return null;
            }

            return this.gestionarProductoDA.GetProducto(id);
        }

    }
}
