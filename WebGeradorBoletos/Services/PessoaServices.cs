using WebGeradorBoletos.Models;
using WebGeradorBoletos.Services.Interfaces;
using WebGeradorBoletos.Services.Utils;

namespace WebGeradorBoletos.Services
{
    public class PessoaServices : IPessoa
    {
        private readonly HttpClient _client;
        private const string _url = "/api/Pessoa";

        public PessoaServices(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<PessoaMd>> FindAll()
        {
            var response = await _client.GetAsync(_url);
            return await response.ReadContentAs<List<PessoaMd>>();
        }

        public async Task<PessoaMd> FindById(long id)
        {
            try
            {
                var response = await _client.GetAsync($"{_url}/{id}");
                return await response.ReadContentAs<PessoaMd>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PessoaMd> Create(PessoaMd model)
        {
            var response = await _client.PostAsJson(_url, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<PessoaMd>();
            else throw new Exception("Erro na API");
        }

        public async Task<PessoaMd> Update(PessoaMd model)
        {
            var response = await _client.PutAsJson(_url, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<PessoaMd>();
            else throw new Exception("Erro na API");
        }

        public async Task<bool> DeleteById(long id)
        {
            var response = await _client.DeleteAsync($"{_url}/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else throw new Exception("Erro API");
        }
    }
}
