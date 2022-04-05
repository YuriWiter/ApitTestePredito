using DesafioBackEnd.Contexto;
using DesafioBackEnd.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DesafioBackEnd.Repositorios
{
    public class SensorRepositorio : BaseRepositorio, ISensorRepositorio
    {
        private readonly DbSet<Sensor> _dbSet;

        public SensorRepositorio(BaseContexto context) : base(context)
        {
            _dbSet = context.Set<Sensor>();
        }

        #region Leitura

        public virtual async Task<Sensor> BuscarPorId(int id, string[] includes = default, bool tracking = false)
        {
            return await Buscar(x => x.Id == id, includes, tracking).FirstOrDefaultAsync();
        }

        public virtual async Task<Sensor> BuscarComPesquisa(Expression<Func<Sensor, bool>> expression, string[] includes = default, bool tracking = false)
        {
            return await Buscar(expression, includes, tracking).FirstOrDefaultAsync();
        }

        public IQueryable<Sensor> Buscar(Expression<Func<Sensor, bool>> expression, string[] includes = default, bool tracking = false)
        {
            var query = _dbSet.Where(expression);
            if (tracking == false)
                query = query.AsNoTracking();
            if (includes != null)
                foreach (var property in includes)
                    query = query.Include(property);
            return query;
        }

        public async Task<IEnumerable<Sensor>> BuscarTodos(string[] includes = default, bool tracking = false)
        {
            return await Buscar(x => true, includes, tracking).ToListAsync();
        }

        public async Task<IEnumerable<Sensor>> BuscarTodosComPesquisa(Expression<Func<Sensor, bool>> expression, string[] includes = default, bool tracking = false)
        {
            return await Buscar(expression, includes, tracking).ToListAsync();
        }

        #endregion

        #region Escrita

        public async Task<int> Incluir(Sensor entidade)
        {
            await IniciarTransaction();
            var obj = await _dbSet.AddAsync(entidade);
            await SalvarMudancas();
            return obj.Entity.Id;
        }

        public async Task<List<Sensor>> IncluirLista(List<Sensor> entidades)
        {
            await IniciarTransaction();
            await _dbSet.AddRangeAsync(entidades);
            await SalvarMudancas();
            return entidades;
        }

        public async Task<Sensor> Alterar(Sensor entidade)
        {
            await IniciarTransaction();
            _context.Entry(entidade).State = EntityState.Modified;
            await SalvarMudancas();

            return entidade;
        }

        public async Task AlterarLista(List<Sensor> entidades)
        {
            await IniciarTransaction();
            foreach (var entidade in entidades)
            {
                _context.Entry(entidade).State = EntityState.Modified;
            }
            await SalvarMudancas();
        }

        public async Task<bool> Excluir(int id)
        {
            try
            {
                await IniciarTransaction();
                var entidade = await BuscarPorId(id);
                if (entidade != null)
                {
                    _dbSet.Remove(entidade);
                }
                await SalvarMudancas();
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}
