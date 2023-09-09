using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//**************************************+
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoStore.EN
{
    public class Registro
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Correo es Obligatorio")]
        [StringLength(100, ErrorMessage = "Maximo 100 Caracteres")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Usuario es Obligatorio")]
        [StringLength(50, ErrorMessage = "Maximo 50 Caracteres")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Contraseña es Obligatorio")]
        [StringLength(50, ErrorMessage = "Maximo 50 Caracteres")]
        public string Contraseña { get; set; }
    }
}
