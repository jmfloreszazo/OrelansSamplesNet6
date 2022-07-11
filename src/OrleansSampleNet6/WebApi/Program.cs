using Orleans;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

var client = ConnectToOrleans().Result;
builder.Services.AddSingleton<IClusterClient>(client);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

async Task<IClusterClient> ConnectToOrleans()
{
    var c = new ClientBuilder()
        .UseLocalhostClustering().Build();
    await c.Connect(); 
    return c;
}