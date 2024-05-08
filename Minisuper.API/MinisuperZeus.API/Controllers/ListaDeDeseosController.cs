﻿using Microsoft.AspNetCore.Mvc;
using MinisuperZeus.BC.Constantes;
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
        [HttpGet("TotalAPagarConIVA/")]
        public async Task<decimal> TotalAPagarConIVA()
        {
            return await this.gestionarListaDeDeseosBW.TotalAPagarConIVA(ImpuestoIVACostaRica.IVA);
        }

        // POST api/<ListaDeDeseosController>
        [HttpPost("AgregarALaLista/")]
        public async Task<bool> AgregarALaLista(int idProducto)
        {
           return await this.gestionarListaDeDeseosBW.AgregarALaLista(idProducto);
        }

        // PUT api/<ListaDeDeseosController>/5
        [HttpPut("AgregarCantidadProducto/")]
        public async Task<bool> AgregarCantidadProducto(int idProducto, int cantidad)
        {
            return await this.gestionarListaDeDeseosBW.AgregarCantidadProducto(idProducto, cantidad);
        }

        // PUT api/<ListaDeDeseosController>/5
        [HttpPut("EliminarCantidadProducto/")]
        public async Task<bool> EliminarCantidadProducto(int idProducto, int cantidad)
        {
            return await this.gestionarListaDeDeseosBW.EliminarCantidadProducto(idProducto, cantidad);
        }

        // DELETE api/<ListaDeDeseosController>/5
        [HttpDelete("EliminarDeLaLista/")]
        public async Task<bool> EliminarDeLaLista(int idProducto)
        {
            return await this.gestionarListaDeDeseosBW.EliminarDeLaLista(idProducto);
        }

    }
}