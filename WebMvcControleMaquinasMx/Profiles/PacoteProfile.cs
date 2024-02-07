using AutoMapper;
using WebMvc_Domain.Domain;
using WebMvcControleMaquinasMx.Models;

namespace WebMvcControleMaquinasMx.Profiles
{
    public class PacoteProfile : Profile
    {
        public PacoteProfile()
        {
            CreateMap<Pacote, PacoteViewModel>().ReverseMap();
        }
    }
}
