var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//Adiciona o servi�o do Swagger
builder.Services.AddSwaggerGen();

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
