using Microsoft.AspNetCore.Mvc;
using MinisuperZeus.API.Utilitarios;
using MinisuperZeus.BC.Constantes;
using MinisuperZeus.BC.Modelos;
using MinisuperZeus.BW.Interfaces.BW;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MinisuperZeus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaDeDeseosController : ControllerBase
    {
        private readonly IGestionarListaDeDeseosBW gestionarListaDeDeseosBW;

        public ListaDeDeseosController(IGestionarListaDeDeseosBW gestionarListaDeDeseosBW) 
        {
            this.gestionarListaDeDeseosBW = gestionarListaDeDeseosBW;
        }

        // GET: api/<ListaDeDeseosController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> GetProductos()
        {
            var deseos = await this.gestionarListaDeDeseosBW.GetListaDeDeseos();

            if (deseos is null)
            {
                return NotFound(null);
            }

            return Ok(DeseoDTOMapper.ConvertirDeseosADeseosDTOs(deseos));
        }

        // GET: api/<ListaDeDeseosController>
        [HttpGet("TotalAPagarConIVA/")]
        public async Task<ActionResult<float>> TotalAPagarConIVA()
        {
            return await this.gestionarListaDeDeseosBW.TotalAPagarConIVA(ImpuestoIVACostaRica.IVA);
        }

        // POST api/<ListaDeDeseosController>
        [HttpPost("AgregarALaLista/")]
        public async Task<ActionResult<bool>> AgregarALaLista(int idProducto)
        {
           return await this.gestionarListaDeDeseosBW.AgregarALaLista(idProducto);
        }

        // PUT api/<ListaDeDeseosController>/5
        [HttpPut("AgregarCantidadProducto/")]
        public async Task<ActionResult<bool>> AgregarCantidadProducto(int idProducto, int cantidad)
        {
            return await this.gestionarListaDeDeseosBW.AgregarCantidadProducto(idProducto, cantidad);
        }

        // PUT api/<ListaDeDeseosController>/5
        [HttpPut("EliminarCantidadProducto/")]
        public async Task<ActionResult<bool>> EliminarCantidadProducto(int idProducto, int cantidad)
        {
            return await this.gestionarListaDeDeseosBW.EliminarCantidadProducto(idProducto, cantidad);
        }

        // DELETE api/<ListaDeDeseosController>/5
        [HttpDelete("EliminarDeLaLista/")]
        public async Task<ActionResult<bool>> EliminarDeLaLista(int idProducto)
        {
            return await this.gestionarListaDeDeseosBW.EliminarDeLaLista(idProducto);
        }

    }
}
