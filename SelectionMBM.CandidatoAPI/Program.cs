using AutoMapper;
using Microsoft.OpenApi.Models;
using SelectionMBM.CandidatoAPI.ConfigAutoMapper;
using SelectionMBM.CandidatoAPI.Repository;
using SelectionMBM.CandidatoAPI.Repository.Interface;
using SelectionMBM.CandidatoAPI.Service;
using SelectionMBM.CandidatoAPI.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Configuração AutoMapper
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ICandidatoRepository, CandidatoRepository>();
builder.Services.AddScoped<ICandidatoService, CandidatoService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Seleção MBM CandidatoAPI", Version = "v1" }); 
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
