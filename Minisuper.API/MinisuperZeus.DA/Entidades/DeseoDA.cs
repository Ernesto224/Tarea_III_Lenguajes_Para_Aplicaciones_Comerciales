using MinisuperZeus.BC.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MinisuperZeus.DA.Entidades
{
    [Table("ListaDeDeseos")]
    public class DeseoDA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IDDeseo { get; set; }
        
        [Required]
        public int IDProducto { get; set; }

        [ForeignKey("IDProducto")]
        public virtual ProductoDA? Producto { get; set; }

        public int Cantidad { get; set; } = 1;
    }
}
