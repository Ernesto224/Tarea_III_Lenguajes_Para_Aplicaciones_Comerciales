using Microsoft.EntityFrameworkCore;
using MinisuperZeus.BC.Constantes;
using MinisuperZeus.BC.Modelos;
using MinisuperZeus.BW.Interfaces.DA;
using MinisuperZeus.DA.Contexto;
using MinisuperZeus.DA.Entidades;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinisuperZeus.DA.Acciones
{
    public class GestionarListaDeDeseosDA : IGestionarListaDeDeseosDA
    {
        private readonly MinisuperZeusContext minisuperZeusContext;

        public GestionarListaDeDeseosDA(MinisuperZeusContext minisuperZeusContext)
        {
            this.minisuperZeusContext = minisuperZeusContext;
        }

        /*
         * Este metodo tiene como objetivo agregar un nuevo producto a la lista de deseos,
         * y ya que el deseao tendra su propio id y la cantidad de producto sera por defecto 1,
         * solo se requiere crear el deseo pasando el idProducto resivido, y al momento de guardar los cambios
         * se recupera el resultado de la operacion para saber si fue posible crear la tupla, esto tambien verificara
         * que el producto exista ya que al ser una llave forania si no existe no se podra hacer el guardado de cambios,
         * por lo que se retornara falso, en el caso de que todo se logre completar retorna verdadero
         */
        public async Task<bool> AgregarALaLista(int idProducto)
        {
            var productoDa = await this.minisuperZeusContext.productoDAs.FindAsync(idProducto);

            if (productoDa is null)
            {
                return false;
            }

            var deseoDA = await this.minisuperZeusContext.deseoDAs
                .FirstOrDefaultAsync(deseoRecuperado => deseoRecuperado.IDProducto == idProducto);

            if (deseoDA != null)
            {
                return await this.AgregarCantidadProducto(idProducto, 1);
            }

            await this.minisuperZeusContext.deseoDAs.AddAsync(new Entidades.DeseoDA() {IDProducto = idProducto});

            var resultado = await this.minisuperZeusContext.SaveChangesAsync();

            if (resultado > 0)
            {
                return true;
            }

            return false;
        }


        /*
         * Este metodo aumentara la cantidad de un producto deciado existente en la lista de deseos,
         * primero se localizara la tupla mediante el idProducto si no existe el producto en la lista de deseos
         * se retornara un false, de lo contrario se procedera a modificar la cantidad existente en la tupla,
         * sumando la cantidad existente con la nueva cantidad, despues se guardan los cambios y si se logro guardar con exito
         * se retorna verdadero
         */
        public async Task<bool> AgregarCantidadProducto(int idProducto, int cantidad)
        {

            var deseoDA = await this.minisuperZeusContext.deseoDAs
                .FirstOrDefaultAsync(deseoRecuperado => deseoRecuperado.IDProducto == idProducto);

            if (deseoDA is null)
            {
                return false;
            }

            deseoDA.Cantidad += cantidad;

            var resultado = await this.minisuperZeusContext.SaveChangesAsync();

            if (resultado > 0)
            {
                return true;
            }

            return false;
        }

        /*
        * Este metodo reducira la cantidad de un producto deciado existente en la lista de deseos,
        * primero se localizara la tupla mediante el idProducto si no existe el producto en la lista de deseos
        * se retornara un false, de lo contrario se procedera a modificar la cantidad existente en la tupla,
        * restando la cantidad existente con la nueva cantidad, en caso de que la cantidad actual menos la resta
        * sea un valor negativo se elimina al producto por completo de la lista de deseos
        * ,despues se guardan los cambios y si se logro guardar con exito se retorna verdadero
        */
        public async Task<bool> EliminarCantidadProducto(int idProducto, int cantidad)
        {
            var deseoDA = await this.minisuperZeusContext.deseoDAs
                           .FirstOrDefaultAsync(deseoRecuperado => deseoRecuperado.IDProducto == idProducto);

            if (deseoDA is null)
            {
                return false;
            }

            if ((deseoDA.Cantidad - cantidad) <= 0)
            {
                return await this.EliminarDeLaLista(idProducto);
            }

            deseoDA.Cantidad -= cantidad;

            var resultado = await this.minisuperZeusContext.SaveChangesAsync();

            if (resultado > 0)
            {
                return true;
            }

            return false;
        }

        /*
         * Este metodo se encarga de eliminar un producto de la lista de deseos, esto la realiza buscando el deseo que contiene
         * a el idProducto, luego se ulizara la funcion remove para eliminar la tupla del catalogo, en caso de no exitir dicho producto
         * se retorna falso indicando que no esta en la lista de deseos, y si todo resulta correcto se guardan los cambios y se retorna
         * verdadero
         */
        public async Task<bool> EliminarDeLaLista(int idProducto)
        {
            var deseoDA = await this.minisuperZeusContext.deseoDAs
               .FirstOrDefaultAsync(deseoRecuperado => deseoRecuperado.IDProducto == idProducto);

            if (deseoDA is null)
            {
                return false;
            }

            this.minisuperZeusContext.deseoDAs.Remove(deseoDA);

            var resultado = await this.minisuperZeusContext.SaveChangesAsync();

            if (resultado > 0)
            {
                return true;
            }

            return false;
        }

        /*
         * Este metodo se dedica a calcular el monto total a pagar de los productos de la lista de deseos, multiplicando el precio individual de cada
         * producto por su cantidad, para esto se optienen los valores de deseo, como lo que seria el producto y la cantidad, luego se verifica si hay productos
         * validos sino el monto de pago es 0, de lo contrario se realiza la suma de los elementos necesarios de la lista  de valores, luego calcula el valor del 
         * impuesto y por ultimo calcula el total para retornarlo.
         */
        public async Task<decimal> TotalAPagarConIVA(decimal impuesto)
        {
            var valores = await this.minisuperZeusContext.deseoDAs.Select(deseo => new { Precio = deseo.Producto.Precio, Cantidad = deseo.Cantidad }).ToListAsync();

            if (valores is null)
            {
                return 0.0m;
            }

            decimal sumaMontos = valores.Sum(valores => valores.Precio * valores.Cantidad);

            decimal valorInpuesto = sumaMontos * impuesto;

            decimal totalAPagar = sumaMontos + valorInpuesto;

            return totalAPagar;

        }
    }
}
