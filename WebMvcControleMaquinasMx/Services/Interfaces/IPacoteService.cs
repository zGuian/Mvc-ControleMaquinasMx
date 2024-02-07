using WebMvc_Domain.Domain;

namespace WebMvcControleMaquinasMx.Services.Interfaces
{
    public interface IPacoteService : IDisposable
    {
        Task<IEnumerable<Pacote>> BuscarPacotes();
        Task<Pacote> BuscarPacotes(int id);
        Task<Pacote> CadastrarPacote(Pacote pacote);
        Task<Pacote> AtualizarPacote(Pacote pacote, int id);
        Task<bool> DeletaPacote(int id);
    }
}
