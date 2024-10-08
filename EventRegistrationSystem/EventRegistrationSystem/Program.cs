using EventRegistrationSystem.Data;
using EventRegistrationSystem.Repository.Interfaces;
using EventRegistrationSystem.Repository.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<EventsDbContext>(options => options.UseSqlServer(ConnectionString));
builder.Services.AddScoped<MailjetService>();
builder.Services.AddScoped(provider =>
{
    var
    configuration = provider.GetRequiredService<IConfiguration>();
    string
    apiKey = configuration[
    "Mailjet:ApiKey"
    ];
    string
    secretKey = configuration[
    "Mailjet:SecretKey"
    ];
    return
    new
    Mailjet.Client.MailjetClient(apiKey, secretKey);
});
builder.Services.AddScoped<IEvents, EventsServicese>();
// Add services to the container.
builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();