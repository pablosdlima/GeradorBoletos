using WebGeradorBoletos.Models;

namespace WebGeradorBoletos.Services.Interfaces
{
    public interface IPessoa
    {
        Task<IEnumerable<PessoaMd>> FindAll();
        Task<PessoaMd> FindById(long id);
        Task<PessoaMd> Create(PessoaMd model);
        Task<PessoaMd> Update(PessoaMd model);
        Task<bool> DeleteById(long id);
    }
}
