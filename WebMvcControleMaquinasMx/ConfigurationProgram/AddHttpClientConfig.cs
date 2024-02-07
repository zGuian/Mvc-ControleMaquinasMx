using WebMvcControleMaquinasMx.Services;
using WebMvcControleMaquinasMx.Services.Interfaces;

namespace WebMvcControleMaquinasMx.ConfigurationProgram
{
    public static class AddHttpClientConfig
    {
        public static void AddHttpClientConfiguration(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddHttpClient<IMaquinaService, MaquinaService>(c =>
            c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:MaquinasAPI"]));
            services.AddHttpClient<IPacoteService, PacoteService>(c =>
            c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:MaquinasAPI"]));
        }
    }
}
