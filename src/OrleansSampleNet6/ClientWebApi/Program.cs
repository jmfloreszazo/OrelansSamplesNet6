using Grains;
using Orleans;
using Orleans.Hosting;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

var siloBuilder = new SiloHostBuilder()
    .UseLocalhostClustering().Configure<Orleans.Configuration.ClusterOptions>(options =>
    {
        options.ClusterId = "dev";
        options.ServiceId = "Test";
    })
    .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(SampleGrain).Assembly).WithReferences())
    .ConfigureLogging(logging => logging.AddConsole());
var host = siloBuilder.Build();
await host.StartAsync();

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