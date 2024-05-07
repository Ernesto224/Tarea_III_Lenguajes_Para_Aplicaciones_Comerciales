using MinisuperZeus.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinisuperZeus.BW.Interfaces.BW
{
    public interface IGestionarProductoBW
    {
        public Task<IEnumerable<Producto>> GetProductos();
    }
}
