using System.ComponentModel.DataAnnotations;
using WebMvc_Domain.Enum;

namespace WebMvcControleMaquinasMx.Models.Maquinas
{
    public class CriarMaquinaViewModel
    {
        [Required(ErrorMessage = "Informe um inventario valido")]
        public string Inventario { get; set; }

        [Required(ErrorMessage = "Informe um hostname valido")]
        public string Hostname { get; set; }
        public bool Ondeso { get; set; }
        public Criticidade Criticidade { get; set; }
        //public List<int> PacotesId { get; set; }
        //public IEnumerable<PacoteViewModel> Pacotes { get; set; }
        //public List<int> PacoteMaquinasId { get; set; }
        //public SelectList PacoteOptionsDisponiveis { get; set; }
        //public SelectList PacoteOptionsAssociados { get; set; }
    }
}
