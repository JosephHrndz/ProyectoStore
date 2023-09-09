using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoStore.EN
{
    public class Comprar
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre es Obligatorio")]
        [StringLength(100, ErrorMessage = "Maximo 100 Caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Apellido es Obligatorio")]
        [StringLength(100, ErrorMessage = "Maximo 100 Caracteres")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Telefono es Obligatorio")]
        public int Telefono { get; set; }
        [Required(ErrorMessage = "Direccion es Obligatorio")]
        [StringLength(299, ErrorMessage = "Maximo 299 Caracteres")]
        public string Direccion { get; set; }
    }
}
