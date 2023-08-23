using ApiPessoas.Enum;

namespace ApiPessoas.Model.ValueObjects
{
    public class PessoaVo
    {
        public string Nome { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public TipoFuncao TipoFuncao { get; set; }
        public string Documento { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
