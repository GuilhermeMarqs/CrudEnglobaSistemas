using CrudCadastroFuncionario.Context;
using CrudCadastroFuncionario.Interfaces;
using CrudCadastroFuncionario.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudCadastroFuncionario.Repository
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(ContextDataBase context) : base(context)
        {
        }
        public  Funcionario ObterFuncionarioEndereco(Guid id)
        {
            return Db.Funcionario.AsNoTracking()
                .Include(c => c.Endereco)
                .FirstOrDefault(c => c.Id == id);
        }
    }
}
