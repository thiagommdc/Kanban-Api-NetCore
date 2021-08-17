using System;
using Xunit;
using Dominio.DTO;
using Dominio;
using Dominio.Entidades;
using System.Collections.Generic;
using AutoMapper;

namespace TesteUnitario
{
    public class KanbanTeste
    {
        private readonly IMapper _mapper;

        public KanbanTeste()
        {            
            new MappinProfile();
        }

        [Fact]
        public void TesteDeMapeamentoDeEntidades()
        {
            var Verificacoes = new List<bool>();

            Verificacoes.Add(VerificaMapeamento<tblUsuario, UsuarioDTO>());
            Verificacoes.Add(VerificaMapeamento<tblTarefa, TarefaDTO>());
            Verificacoes.Add(VerificaMapeamento<tblEtapa, EtapaDTO>());

            foreach (var item in Verificacoes)
            {
                if (!item)
                {
                    Assert.True(item);
                    break;
                }
            }
        }

        private bool VerificaMapeamento<T, K>() where T : new()
        {
            var Populado = PopularObjeto<T>();
            var Mapeado = _mapper.Map<K>(Populado);
            var Remapeado = _mapper.Map<T>(Mapeado);
            var Lista = typeof(T).GetProperties();

            foreach (var item in Lista)
            {
                var valorPopulado = Populado.GetType().GetProperty(item.Name).GetValue(Populado, null);
                var valorRemapeado = Remapeado.GetType().GetProperty(item.Name).GetValue(Remapeado, null);

                if (item.Name.Contains("dte"))
                    continue;

                if (valorPopulado != null && valorRemapeado != null)
                    if (valorPopulado.ToString() != valorRemapeado.ToString())
                        return false;
            }
            return true;
        }

        private T PopularObjeto<T>() where T : new()
        {
            var Objeto = new T();
            var Lista = typeof(T).GetProperties();
            Random rnd = new Random();
            var Tipos = new List<string> { "Int32", "String" };

            foreach (var item in Lista)
            {
                if (!Tipos.Contains(item.PropertyType.Name))
                    continue;

                int valor = rnd.Next();
                var Propriedade = Objeto.GetType().GetProperty(item.Name);
                var ValorConvertido = Convert.ChangeType(valor, Propriedade.PropertyType);
                Objeto.GetType().GetProperty(item.Name).SetValue(Objeto, ValorConvertido, null);
            }
            return Objeto;
        }
    }
}
