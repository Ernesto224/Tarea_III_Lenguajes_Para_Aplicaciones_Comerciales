using MinisuperZeus.BC.Modelos;
using MinisuperZeus.BW.Interfaces.BW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinisuperZeus.BW.CU
{
    public class GestionarProductoBW : IGestionarProductoBW
    {
        public Task<IEnumerable<Producto>> GetProductos()
        {
            throw new NotImplementedException();
        }
    }
}
