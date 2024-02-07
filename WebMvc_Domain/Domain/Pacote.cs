namespace WebMvc_Domain.Domain
{
    public class Pacote
    {   
        public int Id { get; set; }
        public string NomeKb { get; set; }
        public DateTime? DataInstalacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public int MaquinasId { get; set; }
        public Maquina Maquinas { get; set; }

    }
}
