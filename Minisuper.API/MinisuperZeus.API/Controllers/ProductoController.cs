using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinisuperZeus.BC.Modelos;
using MinisuperZeus.BW.CU;

namespace MinisuperZeus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly GestionarProductoBW gestionarProductoBW;

        public ProductoController(GestionarProductoBW gestionarProductoBW)
        {
            this.gestionarProductoBW = gestionarProductoBW;
        }

        [HttpGet]
        public Task<ActionResult<IEnumerable<ProductoDTO>>> GesProductos() 
        { 
            return null; 
        }

    }
}
