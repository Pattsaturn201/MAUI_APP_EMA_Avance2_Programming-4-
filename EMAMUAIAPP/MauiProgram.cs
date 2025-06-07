using Microsoft.Extensions.Logging;

namespace EMAMUAIAPP
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Register HttpClient here
            builder.Services.AddSingleton(new HttpClient
            {
                BaseAddress = new Uri("https://localhost:5001/api/")
            });
            builder.Services.AddSingleton<ClientesService>();
            builder.Services.AddSingleton<EmpleadosService>();
            builder.Services.AddSingleton<EmpresaServices>();
            builder.Services.AddSingleton<EquipoServices>();
            builder.Services.AddSingleton<OrdenTrabajoServices>();
            builder.Services.AddSingleton<PagosServices>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
