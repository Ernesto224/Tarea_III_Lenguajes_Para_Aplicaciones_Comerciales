using MinisuperZeus.BC.Modelos;
using System.Threading;

namespace MinisuperZeus.API.Utilitarios
{
    public static class ProductoDTOMapper 
    {
        public static IEnumerable<ProductoDTO> ConvertirProductosAProductoDTOs(IEnumerable<ProductoDTO> productos) 
        {
            IEnumerable<ProductoDTO> productosDTO = productos.Select(Producto => new ProductoDTO()
                {
                    IDProducto = Producto.IDProducto,
                    NombreProducto = Producto.NombreProducto,
                    Precio = Producto.Precio,
                }
            );
            return productosDTO;
        } 
    }
}
