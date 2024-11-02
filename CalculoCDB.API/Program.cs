using CalculoCDB.API;
using CalculoCDB.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigAPI();

var app = builder.Build();

app.CheckDevModeConfig(builder.Environment);

app.AddCDBEndpoints();

await app.RunAsync();