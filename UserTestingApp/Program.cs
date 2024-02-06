using Microsoft.EntityFrameworkCore;
using UserTestingApp.DAL.EF;
using UserTestingApp.DAL.Repository.Interface;
using UserTestingApp.DAL.Repository;
using UserTestingApp.BLL.Profiles;
using UserTestingApp.BLL.Services;
using UserTestingApp.BLL.Services.Interfaces;
using UserTestingApp.Common.Models;

namespace UserTestingApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

            //Mapper
            builder.Services.AddAutoMapper(typeof(UserProfile));

            // DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Repository
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Service
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //CORS
            builder.Services.AddCors(options => options
                .AddDefaultPolicy(build => build
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors(opt => opt.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}