namespace GeradorBoletos.Models
{
    public class PessoaMd
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string TipoPessoa { get; set; }
        public string TipoFuncao { get; set; }
        public string Documento { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}