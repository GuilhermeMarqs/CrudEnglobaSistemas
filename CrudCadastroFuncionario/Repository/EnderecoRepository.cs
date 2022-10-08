using CrudCadastroFuncionario.Context;
using CrudCadastroFuncionario.Interfaces;
using CrudCadastroFuncionario.Models;

namespace CrudCadastroFuncionario.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(ContextDataBase context) : base(context)
        {
        }
    }
}
