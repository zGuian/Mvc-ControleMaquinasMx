using Microsoft.AspNetCore.Mvc.Rendering;
using WebMvc_Domain.Domain;

namespace WebMvcControleMaquinasMx.Models
{
    public class PacoteViewModel
    {
        public int Id { get; set; }
        public string NomeKb { get; set; }
        public int MaquinasId { get; set; }
        public DateTime DataInstalacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public Maquina Maquinas { get; set; }
        public SelectList PacotesOptions { get; set; }
    }
}
