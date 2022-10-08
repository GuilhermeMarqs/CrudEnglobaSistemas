using CrudCadastroFuncionario.Models;

namespace CrudCadastroFuncionario.Interfaces
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
        Funcionario ObterFuncionarioEndereco(Guid id);
    }
}
