using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using KatmanliMimariApi.Api.Filters;
using KatmanliMimariApi.Api.Middleware;
using KatmanliMimariApi.Api.Moduls;
using KatmanlýMimariApi.Core.Repositories;
using KatmanlýMimariApi.Core.Services;
using KatmanlýMimariApi.Core.UnitOfWorks;
using KatmanliMimariApi.Repository;
using KatmanliMimariApi.Repository.Repository;
using KatmanliMimariApi.Repository.UnitOfWork;
using KatmanliMimariApi.Services.Mapping;
using KatmanliMimariApi.Services.Services;
using KatmanliMimariApi.Services.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt =>  opt.Filters.Add(new ValidaterFilterAtribute())).AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidation>());
builder.Services.Configure<ApiBehaviorOptions>(opt=>
{
    opt.SuppressModelStateInvalidFilter = true;//cancel model from fluent library and return my model 
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddScoped(typeof(NotFoundFilter<>));
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), options =>
{
    options.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
}));
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModul()));
// we added autofac library 


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCustomException();


app.UseAuthorization();

app.MapControllers();

app.Run();
