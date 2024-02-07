using AutoMapper;
using WebMvc_Domain.Domain;
using WebMvc_Utilities.HttpConfiguration;
using WebMvcControleMaquinasMx.Models.Maquinas;
using WebMvcControleMaquinasMx.Services.Interfaces;

namespace WebMvcControleMaquinasMx.Services
{
    public class MaquinaService : IMaquinaService
    {
        private const string BasePath = "api/v1/maquina";
        private readonly HttpClient _client;
        private readonly IMapper _mapper;

        public MaquinaService(HttpClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MaquinaViewModel>> BuscarMaquinas()
        {
            var response = await _client.GetAsync(BasePath);
            var responseConvertido = _mapper.Map<IEnumerable<MaquinaViewModel>>(
                await response.LerJsonAsync<IEnumerable<Maquina>>());
            return responseConvertido;
        }

        public async Task<MaquinaViewModel> BuscarMaquinas(int id)
        {
            var response = await _client.GetAsync($"{BasePath}/GetId/{id}");
            return await response.LerJsonAsync<MaquinaViewModel>();
        }

        public async Task<CriarMaquinaViewModel> CadastrarMaquinas(CriarMaquinaViewModel maquina)
        {
            //ADICIONAR TRATAMENTO DE ERRO
            var response = await _client.EscreveJsonAsync(BasePath, maquina);
            if (response.IsSuccessStatusCode)
            {
                return _mapper.Map<CriarMaquinaViewModel>(await response.LerJsonAsync<CriarMaquinaViewModel>());
            }
            throw new Exception("algo deu errado!");
        }

        public async Task<EditarMaquinaViewModel> AtualizarMaquina(EditarMaquinaViewModel maquina, int id)
        {
            var response = await _client.AttJsonAsync($"{BasePath}/Update/{id}", maquina);
            if (response.IsSuccessStatusCode)
            {
                return _mapper.Map<EditarMaquinaViewModel>(await response.LerJsonAsync<EditarMaquinaViewModel>());
            }
            throw new Exception("algo deu errado!");
        }

        public async Task<bool> DeletaMaquina(int id)
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
