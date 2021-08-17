using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class tblEtapa
    {
        [Key]
        public int intEtapaID { get; set; }
        public int intOrdem { get; set; }
        public string txtNome { get; set; }

    }
}