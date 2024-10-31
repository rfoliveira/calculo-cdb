using CalculoCDB.API;
using CalculoCDB.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigAPI();

var app = builder.Build();

app.CheckDevModeConfig(builder.Environment);

app.UseHttpsRedirection();
app.AddCDBEndpoints();

app.Run();