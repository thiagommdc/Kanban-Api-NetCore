using AutoMapper;
using Dominio.DTO;
using Dominio.Entidades;

namespace Dominio
{
    public class MappinProfile : Profile
    {
        public MappinProfile()
        {
            CreateMap<tblUsuario, UsuarioDTO>()
            .ForMember(m => m.Id, opt => opt.MapFrom(x => x.intUsuarioID))
            .ForMember(m => m.Nome, opt => opt.MapFrom(x => x.txtNome)).ReverseMap();
            
            CreateMap<tblEtapa, EtapaDTO>()
            .ForMember(m => m.Id, opt => opt.MapFrom(x => x.intEtapaID))
            .ForMember(m => m.Ordem, opt => opt.MapFrom(x => x.intOrdem))
            .ForMember(m => m.Nome, opt => opt.MapFrom(x => x.txtNome)).ReverseMap();

            CreateMap<tblTarefa, TarefaDTO>()
            .ForMember(m => m.Id, opt => opt.MapFrom(x => x.intTarefaID))
            .ForMember(m => m.UsuarioId, opt => opt.MapFrom(x => x.intUsuarioID))
            .ForMember(m => m.Titulo, opt => opt.MapFrom(x => x.txtTitulo))
            .ForMember(m => m.Subtitulo, opt => opt.MapFrom(x => x.txtSubtitulo))
            .ForMember(m => m.Descricao, opt => opt.MapFrom(x => x.txtDescricao))
            .ForMember(m => m.DataCadastro, opt => opt.MapFrom(x => x.dteCadastro))
            .ForMember(m => m.Etapa, opt => opt.MapFrom(x => x.intEtapaID))
            .ForMember(m => m.Favorito, opt => opt.MapFrom(x => x.bitFavorito))
            .ForMember(m => m.SeCompleto, opt => opt.MapFrom(x => x.bitCompleto)).ReverseMap();
        }
    }
}