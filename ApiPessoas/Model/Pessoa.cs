using ApiPessoas.Enum;
using ApiPessoas.Model.Base;
using ApiPessoas.Utils.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPessoas.Model
{
    [Table("PessoaTb")]
    public class Pessoa : BaseEntity
    {
        [Column("Nome")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(150, ErrorMessage = "Limite máximo do campo {0} atingido")]
        public string Nome { get; set; }

        [Column("TipoPessoa")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public TipoPessoa TipoPessoa { get; set; }

        [Column("TipoFuncao")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public TipoFuncao TipoFuncao { get; set; }

        [Column("Documento")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        [CpfCnpjValidation(ErrorMessage = "O valor deve ser um CPF ou CNPJ válido.")]
        [StringLength(14, ErrorMessage = "Limite máximo do campo {0} atingido")]
        public string Documento { get; set; }

        [Column("Endereco")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(150, ErrorMessage = "Limite máximo do campo {0} atingido")]
        public string Endereco { get; set; }

        [Column("Telefone")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(20, ErrorMessage = "Limite máximo do campo {0} atingido")]
        public string Telefone { get; set; }

        [Column("Email")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(100, ErrorMessage = "Limite máximo do campo {0} atingido")]
        public string Email { get; set; }
    }
}
