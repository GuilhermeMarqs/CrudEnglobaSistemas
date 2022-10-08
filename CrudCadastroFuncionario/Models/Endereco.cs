using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudCadastroFuncionario.Models
{
    [Table("Endereco")]
    public class Endereco : Entity
    {
        [Display(Name = "Endereço")]
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string? Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string? Referencia { get; set; }

    }
}


