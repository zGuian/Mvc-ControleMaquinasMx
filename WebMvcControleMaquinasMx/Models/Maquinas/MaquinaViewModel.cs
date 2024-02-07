using Microsoft.AspNetCore.Mvc.Rendering;
using WebMvc_Domain.Domain;
using WebMvc_Domain.Enum;

namespace WebMvcControleMaquinasMx.Models.Maquinas
{
    public class MaquinaViewModel
    {
        public int Id { get; set; }
        public string Inventario { get; set; }
        public string Hostname { get; set; }
        public bool Ondeso { get; set; }
        public Criticidade Criticidade { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? UltimaAtualizacao { get; set; }
        public int PacotesId { get; set; }
        public ICollection<Pacote> Pacotes { get; set; }
        public SelectList PacoteOptions { get; set; }
    }
}
