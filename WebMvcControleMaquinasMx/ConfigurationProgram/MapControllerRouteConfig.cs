namespace WebMvcControleMaquinasMx.ConfigurationProgram
{
    public static class MapControllerRouteConfig
    {
        public static void AddMapControllerRouteConfiguration(this WebApplication app)
        {
            app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
