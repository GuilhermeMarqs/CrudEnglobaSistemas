using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudCadastroFuncionario.Models
{
    [Table("Funcionario")]
    public class Funcionario: Entity
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        [StringLength(14, ErrorMessage = "Cpf deve ter entre {0} e {1} caracteres.", MinimumLength = 1)]
        public string Cpf { get; set; }
     
        public string RG { get; set; }
        public string Emissor { get; set; }

        [Display(Name = "Titulo Eleitor")]
        public string TituloEleitor { get; set; }
        public string? CNH { get; set; }
        public bool Gestor { get; set; }

        [Required]
        public bool Ativo { get; set; }
        public Guid EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }  
    }
}
