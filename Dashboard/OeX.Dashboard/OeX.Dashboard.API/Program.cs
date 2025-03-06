using Asp.Versioning.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using OeX.Dashboard.API.Configuration;
using OeX.Dashboard.Application.Empresas.Commands;
using OeX.Dashboard.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RNContext>(options =>
{
    options
        .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddJWTConfig(builder.Configuration);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddApiConfig();

builder.Services.AddSwaggerConfig();

builder.Services.AddControllers();

builder.Services.AddHttpContextAccessor();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMvc();

builder.Services.ResolveDependencies();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateEmpresaCommandHandler).Assembly));

var app = builder.Build();

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseApiConfig(app.Environment);

app.MapControllers();

app.UseSwaggerConfig(apiVersionDescriptionProvider);

app.Run();
