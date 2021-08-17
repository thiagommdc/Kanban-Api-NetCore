using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace BancoDados.Interface
{
    public interface ITarefas
    {
        Task<int> AdicionaUsuario(tblUsuario Usuario);
        Task EditarUsuario(tblUsuario Usuario);
        Task ExcluirUsuario(int UsuarioID);
        Task<List<tblUsuario>> Usuarios();
        Task<int> AdicionaTarefa(tblTarefa Tarefa);
        Task EditaTarefa(tblTarefa Tarefa);
        Task ExcluiTarefa(int? TarefaID, int UsuarioID = 0);
        Task<List<tblTarefa>> ListaTarefas(int UsuarioID);
        Task<List<tblEtapa>> Etapas();
        Task<int> AdicionaEtapa(tblEtapa Etapa);
        Task EditaEtapa(tblEtapa Etapa);
        Task ExcluiEtapa(int EtapaID);
    }
}