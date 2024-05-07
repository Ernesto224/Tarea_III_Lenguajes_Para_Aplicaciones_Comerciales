using MinisuperZeus.BC.Modelos;
using MinisuperZeus.BW.Interfaces.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinisuperZeus.DA.Acciones
{
    public class GestionarProductoDA : IGestionarProductoDA
    {
        public Task<IEnumerable<Producto>> GetProductos()
        {
            throw new NotImplementedException();
        }
    }
}
