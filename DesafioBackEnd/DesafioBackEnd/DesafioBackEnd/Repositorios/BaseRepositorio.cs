using DesafioBackEnd.Contexto;
using System.Threading.Tasks;

namespace DesafioBackEnd.Repositorios
{
    public class BaseRepositorio: IBaseRepositorio
    {
        protected readonly BaseContexto _context;
        public BaseRepositorio(BaseContexto context)
        {
            _context = context;
        }

        public async Task IniciarTransaction()
        {
            await _context.IniciarTransaction();
        }

        public async Task SalvarMudancas(bool commit = true)
        {
            await _context.SalvarMudancas(commit);
        }

        public async Task RollbackTransaction()
        {
            await _context.RollBack();
        }

        public async Task Commit()
        {
            await _context.Commit();
        }
    }
}
