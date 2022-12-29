using ClientesApi.Application.Security;
using ClientesApi.Domain.Interfaces.Repositories;
using ClientesApi.Domain.Interfaces.Services;
using ClientesApi.Domain.Services;
using ClientesApi.Infra.Data.Contexts;
using ClientesApi.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Configurando as injeções de dependência

builder.Services.AddTransient<IClienteDomainService, ClienteDomainService>();
builder.Services.AddTransient<IDependenteDomainService, DependenteDomainService>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IDependenteRepository, DependenteRepository>();
builder.Services.AddTransient<SqlServerContext>();

#endregion

#region Habilitando as configurações de CORS

builder.Services.AddCors(
        s => s.AddPolicy("DefaultPolicy", builder =>
        {
            builder.AllowAnyOrigin() //qualquer origem pode acessar a API
                .AllowAnyMethod() //qualquer método (POST, PUT, DELETE, GET)
                .AllowAnyHeader(); //qualquer informação de cabeçalho
        })
);

#endregion

#region Definindo a política de autenticação

builder.Services.AddAuthentication(
    auth =>
    {
        auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(bearer =>
    {
        bearer.RequireHttpsMetadata = false;
        bearer.SaveToken = true;
        bearer.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtSecurity.SecretKey)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

#endregion

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("DefaultPolicy");

app.MapControllers();

app.Run();

public partial class Program { }



