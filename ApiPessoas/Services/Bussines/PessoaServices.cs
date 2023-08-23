using ApiPessoas.Model;
using ApiPessoas.Model.Data;
using ApiPessoas.Services.Bussines.Interfaces;
using ApiPessoas.Services.Repository;
using Microsoft.EntityFrameworkCore;

namespace ApiPessoas.Services.Bussines
{
    public class PessoaServices : Repository<Pessoa>, IPessoa
    {
        public PessoaServices(Context context) : base(context)
        {
        }
    }
}
