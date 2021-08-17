using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BancoDados.Interface;
using Dominio.DTO;
using AutoMapper;
using System.Collections.Generic;
using Api.Business;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KanbanController : ControllerBase
    {
        private readonly ITarefas _Tarefas;
        private readonly IMapper _mapper;
        private readonly BKanban _BKanban;

        public KanbanController(ITarefas Tarefas, IMapper mapper)
        {
            _Tarefas = Tarefas;
            _mapper = mapper;
            _BKanban = new BKanban(Tarefas, mapper);
        }

        #region Usuario

        [HttpPost("usuario/adicionar/")]
        public async Task<int> AdicionaUsuario(UsuarioDTO Usuario)
        {
            return await _BKanban.AdicionaUsuario(Usuario);
        }

        [HttpPost("usuario/editar/")]
        public async Task EditarUsuario(UsuarioDTO Usuario)
        {
            await _BKanban.EditarUsuario(Usuario);
        }

        [HttpPost("usuario/excluir/")]
        public async Task ExcluirUsuario(int UsuarioId)
        {
            await _BKanban.ExcluirUsuario(UsuarioId);
        }

        [HttpGet("usuarios/")]
        public async Task<List<UsuarioDTO>> Usuarios()
        {
            return await _BKanban.Usuarios();
        }

        #endregion

        #region Tarefa

        [HttpPost("tarefa/adicionar/")]
        public async Task<int> AdicionaTarefa(TarefaDTO Tarefa)
        {
            return await _BKanban.AdicionaTarefa(Tarefa);
        }

        [HttpPost("tarefa/editar/")]
        public async Task EditaTarefa(TarefaDTO Tarefa)
        {
            await _BKanban.EditaTarefa(Tarefa);
        }

        [HttpPost("tarefa/excluir/{TarefaID}")]
        public async Task ExcluiTarefa(int TarefaID)
        {
            await _BKanban.ExcluiTarefa(TarefaID);
        }

        [HttpGet("tarefas/{IdUsuario}")]
        public async Task<List<TarefaDTO>> Tarefas(int IdUsuario)
        {
            return await _BKanban.Tarefas(IdUsuario);
        }

        #endregion

        #region etapas

        [HttpGet("etapas/")]
        public async Task<List<EtapaDTO>> Etapas()
        {
            return await _BKanban.Etapas();
        }

        [HttpPost("etapa/adicionar/")]
        public async Task<int> AdicionaEtapa(EtapaDTO Etapa)
        {
            return await _BKanban.AdicionaEtapa(Etapa);
        }

        [HttpPost("etapa/editar/")]
        public async Task EditaEtapa(EtapaDTO Etapa)
        {
            await _BKanban.EditaEtapa(Etapa);
        }

        [HttpPost("etapa/excluir/{IdEtapa}")]
        public async Task ExcluiEtapa(int IdEtapa)
        {
            await _BKanban.ExcluiEtapa(IdEtapa);
        }

         [HttpPost("teste")]
        public async Task asdasdasdsa(AmbienteInscricoesDTO teste)
        {
            
        }


        

        #endregion etapas

    }
}
