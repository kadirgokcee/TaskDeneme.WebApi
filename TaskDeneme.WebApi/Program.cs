using Application.Services;
using Domain.Repositories.CompanyRepositories;
using Domain.Repositories.OrderRepositories;
using Domain.Repositories.ProductRepositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistance;
using Persistance.Context;
using Persistance.Repositories.CompanyRepositories;
using Persistance.Repositories.OrderRepositories;
using Persistance.Repositories.ProductRepositories;
using Persistance.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

// yar�da b�rak�yorum hatay� ��z�mleyemiyorum assembly'de patl�yor .net6 kaynakl� ya da nuget paketlerle ilgili oldu�unu d���n�yorum
var builder = WebApplication.CreateBuilder(args);

#region DbContext
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
#endregion



#region Dependency Injection
builder.Services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
builder.Services.AddScoped<IProductQueryRepository, ProductQueryRepository>();
builder.Services.AddScoped<ICompanyCommandRepository, CompanyCommandRepository>();
builder.Services.AddScoped<ICompanyQueryRepository, CompanyQueryRepository>();
builder.Services.AddScoped<IOrderCommandRepository, OrderCommandRepository>();
builder.Services.AddScoped<IOrderQueryRepository, OrderQueryRepository>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
#endregion

builder.Services.AddMediatR(typeof(Application.AssemblyReference).Assembly);

builder.Services.AddControllers()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();