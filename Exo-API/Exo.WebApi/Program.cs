using Exo.WebApi.Contexts;
using Exo.WebApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configura a conexão com o banco de dados
builder.Services.AddScoped<ExoContext, ExoContext>();

// Registra o repositório de Projetos
builder.Services.AddTransient<ProjetoRepository, ProjetoRepository>();

// ADICIONE ESTA LINHA:
// Registra o novo repositório de Usuários
builder.Services.AddTransient<UsuarioRepository, UsuarioRepository>();


// Adiciona o serviço de controladores
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();