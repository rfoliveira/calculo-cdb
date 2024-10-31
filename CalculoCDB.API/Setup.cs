using CalculoCDB.API.Repositories;
using CalculoCDB.API.Services;

namespace CalculoCDB.API;

public static class Setup
{
    public static IHostApplicationBuilder ConfigAPI(this IHostApplicationBuilder builder)
    {
        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<ICDBService, CDBService>();
        builder.Services.AddSingleton<ITaxaRepository, TaxaRepository>();

        return builder;
    }

    public static void CheckDevModeConfig(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
