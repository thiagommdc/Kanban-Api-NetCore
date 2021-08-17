using System;

namespace Dominio.DTO
{
    public class TarefaDTO
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }        
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool SeCompleto { get; set; }
        public int Etapa { get; set; }     
        public bool Favorito { get; set; }
        
    }
}