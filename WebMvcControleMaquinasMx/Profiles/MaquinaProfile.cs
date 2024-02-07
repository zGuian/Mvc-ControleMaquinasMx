using AutoMapper;
using WebMvc_Domain.Domain;
using WebMvcControleMaquinasMx.Models;
using WebMvcControleMaquinasMx.Models.Maquinas;

namespace WebMvcControleMaquinasMx.Profiles
{
    public class MaquinaProfile : Profile
    {
        public MaquinaProfile()
        {
            CreateMap<Maquina, MaquinaViewModel>().ReverseMap();
            CreateMap<Maquina, EditarMaquinaViewModel>().ReverseMap();
        }
    }
}
