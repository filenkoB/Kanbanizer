using backend.Infrastructure;
using backend.Service;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

builder.Services.AddInfrastructure();
builder.Services.AddService(configuration);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.WebHost.UseUrls("http://localhost:5001/");

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseCors(configuration =>
{
    configuration.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod();
});

app.MapControllers();
//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();


app.Run();
