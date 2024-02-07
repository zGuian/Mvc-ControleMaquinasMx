using WebMvc_Domain.Domain;
using WebMvc_Utilities.HttpConfiguration;
using WebMvcControleMaquinasMx.Services.Interfaces;

namespace WebMvcControleMaquinasMx.Services
{
    public class PacoteService : IPacoteService
    {
        private const string BasePath = "api/v1/pacote";
        private readonly HttpClient _client;

        public PacoteService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Pacote>> BuscarPacotes()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.LerJsonAsync<IEnumerable<Pacote>>();
        }

        public async Task<Pacote> BuscarPacotes(int id)
        {
            var response = await _client.GetAsync($"{BasePath}/GetId/{id}");
            return await response.LerJsonAsync<Pacote>();
        }

        public async Task<Pacote> CadastrarPacote(Pacote pacote)
        {
            var response = await _client.EscreveJsonAsync(BasePath, pacote);
            if (response.IsSuccessStatusCode)
            {
                return await response.LerJsonAsync<Pacote>();
            }
            throw new Exception("Algo deu errado!");
        }

        public async Task<Pacote> AtualizarPacote(Pacote pacote, int id)
        {
            var response = await _client.AttJsonAsync($"{BasePath}/Update/{id}", pacote);
            if (response.IsSuccessStatusCode)
            {
                return await response.LerJsonAsync<Pacote>();
            }
            throw new Exception("algo deu errado!");
        }

        public async Task<bool> DeletaPacote(int id)
        {
            var response = await _client.DeleteAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.LerJsonAsync<bool>();
            }
            throw new Exception("algo deu errado!");
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
