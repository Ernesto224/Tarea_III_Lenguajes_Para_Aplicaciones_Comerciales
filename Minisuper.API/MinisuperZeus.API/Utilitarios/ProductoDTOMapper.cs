using MinisuperZeus.BC.Modelos;
using System.Threading;

namespace MinisuperZeus.API.Utilitarios
{
    public static class ProductoDTOMapper 
    {
        /*
         * este metodo se utiliza para que la lista de produtos retoenada sea de tipo DTO
         * esto mediante la funcion select, la cual devuele lo objetos almacenados en su interior
         * en forma secuancial hasta el ultimo, y cuando se tiene este se reasigna el tipo de dato 
         */
        public static IEnumerable<ProductoDTO> ConvertirProductosAProductoDTOs(IEnumerable<Producto> productos) 
        {
            IEnumerable<ProductoDTO> productosDTO = productos.Select(producto => new ProductoDTO()
                {
                    IDProducto = producto.IDProducto,
                    NombreProducto = producto.NombreProducto,
                    Precio = producto.Precio,
                    EnStock = producto.Stock > 0
                }
            );
            return productosDTO;
        }

        public static ProductoDTO ConvertirProductoADTO(Producto producto) 
        {
            return new ProductoDTO() {IDProducto = producto.IDProducto, NombreProducto = producto.NombreProducto, Precio = producto.Precio };
        }
    }
}
