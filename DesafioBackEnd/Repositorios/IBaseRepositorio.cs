using System.Threading.Tasks;

namespace DesafioBackEnd.Repositorios
{
    public interface IBaseRepositorio
    {
        Task IniciarTransaction();
        Task SalvarMudancas(bool commit = true);
        Task RollbackTransaction();
        Task Commit();
    }
}
