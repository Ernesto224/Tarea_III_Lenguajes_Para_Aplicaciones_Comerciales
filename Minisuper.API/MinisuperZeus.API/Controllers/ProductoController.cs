using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinisuperZeus.API.Utilitarios;
using MinisuperZeus.BC.Modelos;
using MinisuperZeus.BW.CU;
using MinisuperZeus.BW.Interfaces.BW;

namespace MinisuperZeus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IGestionarProductoBW gestionarProductoBW;

        public ProductoController(IGestionarProductoBW gestionarProductoBW)
        {
            this.gestionarProductoBW = gestionarProductoBW;
        }

        [HttpGet("Productos/")]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> GetProductos() 
        {
            var productos = await this.gestionarProductoBW.GetProductos();

            if (productos is null)
            {
                return NotFound(false);
            }

            return Ok(ProductoDTOMapper.ConvertirProductosAProductoDTOs(productos)); 
        }

        [HttpGet("BuscarProducto/")]
        public async Task<IActionResult> GetProducto(int id)
        {
            var producto = await this.gestionarProductoBW.GetProducto(id);

            if (producto is null)
            {
                return NotFound(false);
            }

            return Ok(ProductoDTOMapper.ConvertirProductoADTO(producto));
        }

    }
}
