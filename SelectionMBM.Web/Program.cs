using SelectionMBM.Web.Service;
using SelectionMBM.Web.Service.IService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IVagaService, VagaService>();
builder.Services.AddHttpClient<IVagaService, VagaService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:44369/");
});

builder.Services.AddScoped<ICandidatoService, CandidatoService>();
builder.Services.AddHttpClient<ICandidatoService, CandidatoService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:44375/");
});

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
