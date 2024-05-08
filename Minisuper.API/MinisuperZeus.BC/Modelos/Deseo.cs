using MinisuperZeus.BC.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MinisuperZeus.DA.Entidades
{
    public class Deseo
    {
        public long IDDeseo { get; set; }
        
        public int IDProducto { get; set; }

        public Producto? Producto { get; set; }

        public int Cantidad { get; set; }
    }
}
