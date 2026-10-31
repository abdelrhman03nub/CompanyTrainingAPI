var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();



builder.Services.AddSwaggerGen();


var app = builder.Build();


var swaggerEnabled = builder.Configuration.GetValue<bool>("Swagger:Enabled");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() && swaggerEnabled)
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
