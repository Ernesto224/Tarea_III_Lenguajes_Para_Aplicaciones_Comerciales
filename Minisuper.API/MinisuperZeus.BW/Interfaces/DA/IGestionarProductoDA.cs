using MinisuperZeus.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinisuperZeus.BW.Interfaces.DA
{
    public interface IGestionarProductoDA
    {
        public Task<IEnumerable<Producto>> GetProductos();

        public Task<Producto> GetProducto(int id);
    }
}
