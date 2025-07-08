using AutoMapper;
using Microsoft.OpenApi.Models;
using SelectionMBM.VagaAPI.ConfigAutoMapper;
using SelectionMBM.VagaAPI.Repository;
using SelectionMBM.VagaAPI.Repository.Interface;
using SelectionMBM.VagaAPI.Service;
using SelectionMBM.VagaAPI.Service.Interface;

var builder = WebApplication.CreateBuilder(args);
// Configuração AutoMapper
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IVagaRepository, VagaRepository>();
builder.Services.AddScoped<IVagaService, VagaService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Seleção MBM VagaAPI", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.UseHttpsRedirection();
app.Run();
