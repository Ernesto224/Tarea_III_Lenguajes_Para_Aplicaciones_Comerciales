﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinisuperZeus.BC.Modelos
{
    public class Producto
    {
        public int IDProducto { get; set; }
        
        public string? NombreProducto { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }
    }
}
