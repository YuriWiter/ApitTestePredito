using DesafioBackEnd.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DesafioBackEnd.Repositorios
{
    public interface ISensorRepositorio
    {
        #region Escrita
        Task<int> Incluir(Sensor entidade);

        Task<List<Sensor>> IncluirLista(List<Sensor>entidade);

        Task<Sensor> Alterar(Sensor entidade);

        Task AlterarLista(List<Sensor>entidades);

        Task<bool> Excluir(int id);
        #endregion

        #region Leitura
        Task<Sensor>BuscarPorId(int id, string[] includes = default, bool tracking = true);

        Task<Sensor>BuscarComPesquisa(Expression<Func<Sensor, bool>> expression, string[] includes = default, bool tracking = true);

        IQueryable<Sensor>Buscar(Expression<Func<Sensor, bool>> expression, string[] includes = default, bool tracking = true);

        Task<IEnumerable<Sensor>> BuscarTodos(string[] includes = default, bool tracking = true);

        Task<IEnumerable<Sensor>> BuscarTodosComPesquisa(Expression<Func<Sensor, bool>> expression, string[] includes = default, bool tracking = true);
        #endregion
    }
}
