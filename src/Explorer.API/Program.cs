using Explorer.API.Hubs;
using Explorer.API.Startup;
using Explorer.Stakeholders.Core.Domain;

using Explorer.Stakeholders.Core.UseCases;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.ConfigureSwagger(builder.Configuration);
const string corsPolicy = "_corsPolicy";
builder.Services.ConfigureCors(corsPolicy);
builder.Services.ConfigureAuth();

builder.Services.RegisterModules();
builder.Services.AddSingleton<PeriodicHostedService>();
builder.Services.AddHostedService(
    provider => provider.GetRequiredService<PeriodicHostedService>());
builder.Services.AddHostedService<UserBackgroundService>();
/*builder.Services.AddHostedService(
    provider => provider.GetRequiredService<UserBackgroundService>());*/


builder.Services.AddSignalR(o =>
{
    o.EnableDetailedErrors = true;
});
var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
//}
//else
//{
//    app.UseExceptionHandler("/error");
//    app.UseHsts();
//}

app.UseRouting();
app.UseCors(corsPolicy);
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthorization();

app.MapHub<PublicSiteHub>("hub");
app.MapHub<EncounterExecutionHub>("api/tourist/encounter/execution");
app.MapControllers();

app.Run();

// Required for automated tests
namespace Explorer.API
{
    public partial class Program { }
}