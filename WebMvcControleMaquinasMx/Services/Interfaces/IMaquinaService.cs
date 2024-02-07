using WebMvcControleMaquinasMx.Models.Maquinas;

namespace WebMvcControleMaquinasMx.Services.Interfaces
{
    public interface IMaquinaService : IDisposable
    {
        Task<IEnumerable<MaquinaViewModel>> BuscarMaquinas();
        Task<MaquinaViewModel> BuscarMaquinas(int id);
        Task<CriarMaquinaViewModel> CadastrarMaquinas(CriarMaquinaViewModel maquina);
        Task<EditarMaquinaViewModel> AtualizarMaquina(EditarMaquinaViewModel maquina, int id);
        Task<bool> DeletaMaquina(int id);
    }
}
