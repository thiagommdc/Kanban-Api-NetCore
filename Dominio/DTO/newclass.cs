using System.Collections.Generic;

namespace Dominio.DTO
{
    public class AmbienteInscricoesDTO
    {
        public string nome { get; set; }
        public int ano { get; set; }
        public bool ad { get; set; }
        public int idaplicacao { get; set; }
        public List<ProdutosAmbienteDTO> produtos { get; set; }
        public List<ObjetosAmbienteDTO> objetos { get; set; }
        public FaqAmbienteDTO faq { get; set; }
    }

    public class ObjetosAmbienteDTO
    {
        public int posicao { get; set; }
        public int tipo { get; set; }
        public string valor { get; set; }
    }

    public class ProdutosAmbienteDTO
    {
        public string titulo { get; set; }
        public string subtitulo { get; set; }
        public string info_adicional { get; set; }
        public bool se_avista { get; set; }
        public bool se_parcelado { get; set; }
        public bool se_entrada_parcelada { get; set; }
        public int quantidade_parcelas { get; set; }
        public string contrato { get; set; }
        public int id_turma { get; set; }
        public int id_template_pagamento { get; set; }
        public int id_filial { get; set; }
        public int id_combo { get; set; }
        public decimal preco { get; set; }
        public decimal preco_cortesia { get; set; }
        public List<List<string>> turmas { get; set; }
    }

    public class FaqAmbienteDTO
    {
        public string Topico { get; set; }
        public int? posicao { get; set; }
        public List<FaqAmbienteSubtopicos> Subtopicos { get; set; }
    }

    public partial class FaqAmbienteSubtopicos
    {
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public int? Posicao { get; set; }
        public int? TopicoPosicao { get; set; }
    }
}