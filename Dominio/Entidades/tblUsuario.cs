using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class tblUsuario
    {
        [Key]
        public int intUsuarioID { get; set; }

        [MaxLength(200)]
        [Required]
        public string txtNome { get; set; }
        
    }
}