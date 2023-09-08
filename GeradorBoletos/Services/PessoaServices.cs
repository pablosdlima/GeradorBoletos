using GeradorBoletos.Models;
using GeradorBoletos.Services.Interfaces;

namespace GeradorBoletos.Services
{
    public class PessoaServices : IPessoa
    {
        public Task<PessoaMd> CreateProduct(PessoaMd model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProductById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PessoaMd>> FindAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<PessoaMd> FindProductById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<PessoaMd> UpdateProduct(PessoaMd model)
        {
            throw new NotImplementedException();
        }
    }
}
