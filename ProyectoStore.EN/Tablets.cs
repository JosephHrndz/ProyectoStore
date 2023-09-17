using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoStore.EN
{
    public class Tablets
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre es Obligatori o")]
        [StringLength(70, ErrorMessage = "Maximo 70 Caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Detalle es Obligatorio")]
        [StringLength(500, ErrorMessage = "Maximo 500 Caracteres")]
        public string Detalle { get; set; }
        [Required(ErrorMessage = "Precio es Obligatorio")]
        public int Precio { get; set; }
        [ForeignKey("Carrito")]
        [Required(ErrorMessage = "Carrito es Obligatorio")]
        [Display(Name = "Carrito")]
        public int IdCarrito { get; set; }
        public int Top_Aux { get; set; }
    }
}
