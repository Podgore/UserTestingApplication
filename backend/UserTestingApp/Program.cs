using Microsoft.EntityFrameworkCore;
using UserTestingApp.DAL.EF;
using UserTestingApp.DAL.Repository.Interface;
using UserTestingApp.DAL.Repository;
using UserTestingApp.BLL.Profiles;
using UserTestingApp.BLL.Services;
using UserTestingApp.BLL.Services.Interfaces;
using UserTestingApp.Common.Models;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FluentValidation.AspNetCore;
using FluentValidation;
using UserTestingApp.Validators.UserValidator;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using UserTestingApp.Middlewares;

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

            builder.Services.AddControllers(cfg => cfg.Filters.Add(typeof(ExceptionFilter)));

            // DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Repository
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Service
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ITestService, TestService>();

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                                {
                                    Reference = new OpenApiReference
                                        {
                                            Type = ReferenceType.SecurityScheme,
                                            Id = "Bearer"
                                        }
                                },
                            Array.Empty<string>()
                        }
                    });
            });

            //Authorization
            builder.Services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ClockSkew = TimeSpan.Zero,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                        ValidAudience = builder.Configuration["JwtSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.ASCII.GetBytes(builder.Configuration["JwtSettings:Secret"]!)
                        ),
                    };
                });

            // Validators
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();
            builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();

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