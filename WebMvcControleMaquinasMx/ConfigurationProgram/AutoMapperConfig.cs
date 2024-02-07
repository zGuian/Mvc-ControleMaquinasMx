using AutoMapper;
using WebMvcControleMaquinasMx.Profiles;

namespace WebMvcControleMaquinasMx.ConfigurationProgram
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MaquinaProfile());
                mc.AddProfile(new PacoteProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
