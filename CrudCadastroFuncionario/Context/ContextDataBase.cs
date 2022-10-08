using CrudCadastroFuncionario.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudCadastroFuncionario.Context
{
    public class ContextDataBase : DbContext
    {
        public ContextDataBase(DbContextOptions<ContextDataBase> options) : base(options)
        {

        }

        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
    }
}
