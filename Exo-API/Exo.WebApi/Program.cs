using Exo.WebApi.Contexts;
using Exo.WebApi.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuração do CORS (Cross-Origin Resource Sharing)
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000") // Permite o seu front-end
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

// 2. Configuração da Autenticação (JWT)
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "exoapi.webapi",
        ValidAudience = "exoapi.webapi",
        IssuerSigningKey = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes("exoapi-chave-autenticacao-segura-e-longa-32")
        )
    };
});

// Adiciona os serviços
builder.Services.AddScoped<ExoContext, ExoContext>();
builder.Services.AddTransient<ProjetoRepository, ProjetoRepository>();
builder.Services.AddTransient<UsuarioRepository, UsuarioRepository>();

builder.Services.AddControllers();

var app = builder.Build();

// ----- Configuração do Pipeline HTTP -----

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

// 3. Habilita o CORS
app.UseCors("CorsPolicy");

// 4. Habilita a Autenticação
app.UseAuthentication();

// 5. Habilita a Autorização
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();