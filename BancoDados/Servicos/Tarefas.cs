using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BancoDados.Interface;
using Dominio.Entidades;

namespace BancoDados.Servicos
{
    class Tarefas : ITarefas
    {
        public async Task<int> AdicionaEtapa(tblEtapa Etapa)
        {
            try
            {
                using (var ctx = new Contexto())
                {
                    ctx.tblEtapa.Add(Etapa);
                    await ctx.SaveChangesAsync();
                    return Etapa.intEtapaID;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("[AdicionaEtapa] : " + ex.Message, ex);
            }
        }

        public async Task<int> AdicionaTarefa(tblTarefa Tarefa)
        {
            try
            {
                using (var ctx = new Contexto())
                {
                    Tarefa.dteCadastro = DateTime.Now;
                    ctx.tblTarefa.Add(Tarefa);
                    await ctx.SaveChangesAsync();
                    return Tarefa.intTarefaID;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("[AdicionaTarefa] : " + ex.Message, ex);
            }
        }

        public async Task<int> AdicionaUsuario(tblUsuario Usuario)
        {
            try
            {
                using (var ctx = new Contexto())
                {
                    ctx.tblUsuario.Add(Usuario);
                    await ctx.SaveChangesAsync();
                    return Usuario.intUsuarioID;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("[AdicionaUsuario] : " + ex.Message, ex);
            }
        }

        public async Task EditaEtapa(tblEtapa Etapa)
        {
            try
            {
                using (var ctx = new Contexto())
                {
                    var EtapaEditada = ctx.tblEtapa.Where(t => t.intEtapaID == Etapa.intEtapaID).FirstOrDefault();
                    EtapaEditada.txtNome = Etapa.txtNome;
                    EtapaEditada.intOrdem = Etapa.intOrdem;
                    await ctx.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("[EditaEtapa] : " + ex.Message, ex);
            }
        }

        public async Task EditarUsuario(tblUsuario Usuario)
        {
            try
            {
                using (var ctx = new Contexto())
                {
                    var UsuarioEditado = ctx.tblUsuario.Where(t => t.intUsuarioID == Usuario.intUsuarioID).FirstOrDefault();
                    UsuarioEditado.txtNome = Usuario.txtNome;
                    await ctx.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("[EditarUsuario] : " + ex.Message, ex);
            }
        }

        public async Task EditaTarefa(tblTarefa Tarefa)
        {
            try
            {
                using (var ctx = new Contexto())
                {
                    var TarefaEditada = ctx.tblTarefa.Where(t => t.intTarefaID == Tarefa.intTarefaID).FirstOrDefault();
                    TarefaEditada.txtTitulo = Tarefa.txtTitulo;
                    TarefaEditada.txtSubtitulo = Tarefa.txtSubtitulo;
                    TarefaEditada.txtDescricao = Tarefa.txtDescricao;
                    TarefaEditada.bitCompleto = Tarefa.bitCompleto;
                    TarefaEditada.intEtapaID = Tarefa.intEtapaID;
                    TarefaEditada.intUsuarioID = Tarefa.intUsuarioID;
                    TarefaEditada.bitFavorito = Tarefa.bitFavorito;
                    await ctx.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("[EditaTarefa] : " + ex.Message, ex);
            }
        }

        public async Task<List<tblEtapa>> Etapas()
        {
            try
            {
                using (var ctx = new Contexto())
                {
                    return ctx.tblEtapa.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("[Etapas] : " + ex.Message, ex);
            }
        }

        public async Task ExcluiEtapa(int EtapaID)
        {
            try
            {
                using (var ctx = new Contexto())
                {
                    var EtapaExclusao = ctx.tblEtapa.Where(t => t.intEtapaID == EtapaID).FirstOrDefault();
                    if (EtapaExclusao == null) throw new Exception("Etapa não encontrada");
                    ctx.tblEtapa.Remove(EtapaExclusao);
                    await ctx.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("[ExcluiEtapa] : " + ex.Message, ex);
            }
        }

        public async Task ExcluirUsuario(int UsuarioID)
        {
            try
            {
                using (var ctx = new Contexto())
                {
                    var UsuarioExclusao = ctx.tblUsuario.Where(t => t.intUsuarioID == UsuarioID).FirstOrDefault();
                    if (UsuarioExclusao == null) throw new Exception("usuário não encontrado");
                    ctx.tblUsuario.Remove(UsuarioExclusao);
                    await ctx.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("[ExcluirUsuario] : " + ex.Message, ex);
            }
        }

        public async Task ExcluiTarefa(int? TarefaID, int UsuarioID = 0)
        {
            try
            {
                using (var ctx = new Contexto())
                {
                    var TarefaExclusao = ctx.tblTarefa.Where(t =>
                    (UsuarioID == 0 && TarefaID != null)
                    ? t.intTarefaID == TarefaID
                    : t.intUsuarioID == UsuarioID
                    ).ToList();

                    if (TarefaExclusao == null) throw new Exception("Tarefa não encontrada");

                    foreach (var item in TarefaExclusao)
                    {
                        ctx.tblTarefa.Remove(item);
                    }
                    await ctx.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("[ExcluiTarefa] : " + ex.Message, ex);
            }
        }

        public async Task<List<tblUsuario>> Usuarios()
        {
            try
            {
                using (var ctx = new Contexto())
                {
                    return ctx.tblUsuario.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("[Usuarios] : " + ex.Message, ex);
            }
        }

        public async Task<List<tblTarefa>> ListaTarefas(int UsuarioID)
        {
            try
            {
                using (var ctx = new Contexto())
                {
                    return ctx.tblTarefa.Where(t => t.intUsuarioID == UsuarioID).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("[Tarefas] : " + ex.Message, ex);
            }
        }
    }
}