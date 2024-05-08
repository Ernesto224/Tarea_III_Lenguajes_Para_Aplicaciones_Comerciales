using Microsoft.EntityFrameworkCore;
using MinisuperZeus.BC.Modelos;
using MinisuperZeus.BW.Interfaces.DA;
using MinisuperZeus.DA.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinisuperZeus.DA.Acciones
{
    public class GestionarProductoDA : IGestionarProductoDA
    {
        private readonly MinisuperZeusContext minisuperZeusContext;

        public GestionarProductoDA(MinisuperZeusContext minisuperZeusContext)
        {
            this.minisuperZeusContext = minisuperZeusContext;
        }

        /*
         * Metodo destinado a realizar las busqueda de todos los productos disponibles
         * en la base de datos de productos, esto mediante lenguaje linqk
         */
        public async Task<IEnumerable<Producto>> GetProductos()
        {
            
            if (minisuperZeusContext.productoDAs is null)
            {
                return null;
            }

            return await this.minisuperZeusContext.productoDAs
                .Select(producto => new Producto() 
                    { 
                        IDProducto = producto.IDProducto, 
                        NombreProducto = producto.NombreProducto,
                        Precio = producto.Precio,
                        Stock = producto.Stock
                    }
                ).ToListAsync();
        }

        /*
         * Buscar el producto mediante el id utiliza la funcion findAync
         * para buscar un producto mediante su id, en caso de no encontrarlo
         * el valor que retorna sera un valor null
         */
        public async Task<Producto> GetProducto(int id)
        {

            if (minisuperZeusContext.productoDAs is null)
            {
                return null;
            }

            var productoDa = await this.minisuperZeusContext.productoDAs.FindAsync(id);

            if (productoDa is null)
            {
                return null;
            }

            return new Producto() { IDProducto = productoDa.IDProducto
                , NombreProducto = productoDa.NombreProducto
                , Precio = productoDa.Precio, Stock = productoDa.Stock };
        }

    }
}
