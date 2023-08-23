using ApiPessoas.Model;
using ApiPessoas.Model.Data;
using ApiPessoas.Model.ValueObjects;
using ApiPessoas.Services.Bussines;
using ApiPessoas.Services.Bussines.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Context"), sqlOptions =>
        sqlOptions.MigrationsAssembly(typeof(Context).Assembly.FullName)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton<IMapper>(sp => sp.GetRequiredService<AutoMapper.IConfigurationProvider>().CreateMapper());
builder.Services.AddSingleton<AutoMapper.IConfigurationProvider>(sp =>
{
    return new MapperConfiguration(config =>
    {
        config.CreateMap<PessoaVo, Pessoa>(); //convert o Vo para model
        config.CreateMap<Pessoa, PessoaVo>(); //convert model para Vo
        //casos de include ().ForMember(dest => dest.NomeCliente, opt => opt.MapFrom(src => src.Atendimento.NomeCliente));

    });
});


builder.Services.AddScoped<IPessoa, PessoaServices>();
//AddScoped: Um serviço escopo (Scoped) é criado uma vez para cada requisição HTTP. 
//AddSingleton: Um serviço singleton é criado apenas uma vez durante todo o tempo de vida
//AddTransient: Um serviço transitório (Transient) é criado toda vez que é solicitado


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
