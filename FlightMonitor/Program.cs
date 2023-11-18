using FlightMonitor.Components;
using FlightMonitor.Infrastructure;
using FlightMonitor.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseInMemoryDatabase("FlightsDb"));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    // The database will be created at this point, including the seeded data
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting(); 

app.UseStaticFiles();
app.UseAntiforgery();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<FlightHub>("/flightHub");
});

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();