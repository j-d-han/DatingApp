using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddControllers();
        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });
        /*
        allow  in order to use it, add it as middleware 'https://localhost:5001/api/users' from origin 'http://localhost:4200' 
        has been blocked by CORS policy: No 'Access-Control-Allow-Origin' header is present on the requested resource.*/
        services.AddCors(); // to use it, add it as middleware. Code below HTTP request pipeline
        services.AddScoped<ITokenService, TokenService>();

        return services;
    }
}
