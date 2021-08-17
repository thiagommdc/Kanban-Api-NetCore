using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class tblTarefa
    {
        [Key]
        public int intTarefaID { get; set; }

        [MaxLength(100)]
        [Required]
        public string txtTitulo { get; set; }

        [MaxLength(100)]
        [Required]
        public string txtSubtitulo { get; set; }

        [Required]
        public string txtDescricao { get; set; }

        public DateTime dteCadastro { get; set; }

        public bool bitCompleto { get; set; }

        public int intUsuarioID { get; set; }

        public int intEtapaID { get; set; }
        
        public bool bitFavorito { get; set; }

    }
}