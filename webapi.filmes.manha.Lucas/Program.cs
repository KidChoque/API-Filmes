using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//Adiciona o servi�o do Swagger
builder.Services.AddSwaggerGen(options =>
{

    //Adiciona informa��es sonbre a API e o swagger
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API-Filmes-Lucas.S.Machado",
        Description = "API que guarda e cadastra filmes e seus g�neros - Introdu��o a API - SPRINT 2",
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


//Inicia a configura��o do Swagger
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
//Termina a configura��o do Swagger

app.MapControllers();   
        
app.Run();
