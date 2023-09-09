using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoStore.EN
{
    public class Carrito
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre de Producto es Obligatorio")]
        [StringLength(100, ErrorMessage = "Maximo 100 Caracteres")]
        public string NombreDeProducto { get; set; }
        [Required(ErrorMessage = "Precio es Obligatorio")]
        public int Precio { get; set; }
        [Required(ErrorMessage = "Envio es Obligatorio")]
        public int Envio { get; set; }
        [Required(ErrorMessage = "Total Apagar es Obligatorio")]
        public int TotalApagar { get; set; }
    }
}
