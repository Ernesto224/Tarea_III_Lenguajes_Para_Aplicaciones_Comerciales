using MinisuperZeus.BC.Modelos;
using MinisuperZeus.DA.Entidades;
using System.Threading;

namespace MinisuperZeus.API.Utilitarios
{
    public static class DeseoDTOMapper 
    {
        /*
         * este metodo se utiliza para que la lista de produtos retoenada sea de tipo DTO
         * esto mediante la funcion select, la cual devuele lo objetos almacenados en su interior
         * en forma secuancial hasta el ultimo, y cuando se tiene este se reasigna el tipo de dato 
         */
        public static IEnumerable<DeseoDTO> ConvertirDeseosADeseosDTOs(IEnumerable<Deseo> deseos) 
        {
            IEnumerable<DeseoDTO> listaDeseosDTO = deseos.Select(deseo => new DeseoDTO()
                {
                   IDDeseo = deseo.IDDeseo,
                   IDProducto = deseo.IDProducto,
                   Cantidad = deseo.Cantidad,
                }
            );
            return listaDeseosDTO;
        }

    }
}
