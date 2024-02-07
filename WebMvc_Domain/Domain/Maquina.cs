using WebMvc_Domain.Enum;

namespace WebMvc_Domain.Domain
{
    public class Maquina
    {
        public int Id { get; set; }
        public string Inventario { get; set; }
        public string Hostname { get; set; }
        public bool Ondeso { get; set; }
        public Criticidade Criticidade { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? UltimaAtualizacao { get; set; }
        public ICollection<Pacote> Pacotes { get; set; }
    }
}
