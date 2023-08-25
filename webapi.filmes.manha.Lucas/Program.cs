using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//Adiciona o serviço do Swagger
builder.Services.AddSwaggerGen(options =>
{

    //Adiciona informações sonbre a API e o swagger
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API-Filmes-Lucas.S.Machado",
        Description = "API que guarda e cadastra filmes e seus gêneros - Introdução a API - SPRINT 2",
        Contact = new OpenApiContact
        {
            Name = "Lucas -KidChoque- Machado",
            Url = new Uri("https://github.com/KidChoque")
        }
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();


//Inicia a configuração do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
//Termina a configuração do Swagger

app.MapControllers();   
        
app.Run();
