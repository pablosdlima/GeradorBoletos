using GeradorBoletos.Models;

namespace GeradorBoletos.Services.Interfaces
{
    public interface IPessoa
    {
        Task<IEnumerable<PessoaMd>> FindAllProducts();
        Task<PessoaMd> FindProductById(long id);
        Task<PessoaMd> CreateProduct(PessoaMd model);
        Task<PessoaMd> UpdateProduct(PessoaMd model);
        Task<bool> DeleteProductById(long id);
    }
}
