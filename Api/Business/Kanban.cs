using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BancoDados.Interface;
using Dominio.DTO;
using Dominio.Entidades;

namespace Api.Business
{
    public class BKanban
    {
        private readonly ITarefas _Tarefas;
        private readonly IMapper _mapper;

        public BKanban(ITarefas Tarefas, IMapper mapper)
        {
            _Tarefas = Tarefas;
            _mapper = mapper;
        }

        #region Usuario

        public async Task<int> AdicionaUsuario(UsuarioDTO Usuario)
        {
            Usuario.Id = 0;
            return await _Tarefas.AdicionaUsuario(_mapper.Map<tblUsuario>(Usuario));
        }

        public async Task EditarUsuario(UsuarioDTO Usuario)
        {
            await _Tarefas.EditarUsuario(_mapper.Map<tblUsuario>(Usuario));
        }

        public async Task ExcluirUsuario(int UsuarioId)
        {
            await _Tarefas.ExcluirUsuario(UsuarioId);
            await _Tarefas.ExcluiTarefa(null, UsuarioId);
        }

        public async Task<List<UsuarioDTO>> Usuarios()
        {
            var ListaUsuarios = await _Tarefas.Usuarios();
            return ListaUsuarios.Select(t => _mapper.Map<UsuarioDTO>(t)).ToList();
        }

        #endregion

        #region Tarefa

        public async Task<int> AdicionaTarefa(TarefaDTO Tarefa)
        {
            Tarefa.Id = 0;
            return await _Tarefas.AdicionaTarefa(_mapper.Map<tblTarefa>(Tarefa));
        }

        public async Task EditaTarefa(TarefaDTO Tarefa)
        {
            await _Tarefas.EditaTarefa(_mapper.Map<tblTarefa>(Tarefa));
        }

        public async Task ExcluiTarefa(int TarefaID)
        {
            await _Tarefas.ExcluiTarefa(TarefaID);
        }

        public async Task<List<TarefaDTO>> Tarefas(int IdUsuario)
        {
            var ListaDeTarefas = await _Tarefas.ListaTarefas(IdUsuario);
            var tarefas = ListaDeTarefas.Select(t => _mapper.Map<TarefaDTO>(t)).ToList();
            return tarefas;
        }

        #endregion

        #region etapas

        public async Task<List<EtapaDTO>> Etapas()
        {
            var ListaEtapas = await _Tarefas.Etapas();
            var Etapas = ListaEtapas.Select(t => _mapper.Map<EtapaDTO>(t)).ToList();
            return Etapas;
        }

        public async Task<int> AdicionaEtapa(EtapaDTO Etapa)
        {
            Etapa.Id = 0;
            return await _Tarefas.AdicionaEtapa(_mapper.Map<tblEtapa>(Etapa));
        }

        public async Task EditaEtapa(EtapaDTO Etapa)
        {
            await _Tarefas.EditaEtapa(_mapper.Map<tblEtapa>(Etapa));
        }

        public async Task ExcluiEtapa(int IdEtapa)
        {
            await _Tarefas.ExcluiEtapa(IdEtapa);
        }

        #endregion etapas

    }
}