using CubeExtension.Core.Interfaces;
using CubeExtension.Core.Services.Implementation;
using CubeExtension.Core.Services.Interfaces;
using CubeExtension.Infrastructure;
using CubeExtension.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<IApplicantService, ApplicantService>();
builder.Services.AddScoped<ICompService, CompService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IHomePageService, HomePageService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//injecting sql 
var conn = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(conn));

//enabling cors
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));


//services.AddCors(opt =>
//{
//    opt.AddDefaultPolicy(builder =>
//    {
//        builder.AllowAnyOrigin()
//            .AllowAnyHeader()
//            .AllowAnyMethod();
//    });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();

app.UseCors("corsapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
