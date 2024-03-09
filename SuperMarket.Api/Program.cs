
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SuperMarket.BL;
using SuperMarket.DL;
using SuperMarket.Model.Data;
using System.Text;
using Microsoft.OpenApi.Models;
using System.Security.Claims;

namespace SuperMarket.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition(name: JwtBearerDefaults.AuthenticationScheme,
                    securityScheme: new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Description = "Enter the Bearer Authorization : 'Bearer Genreated-Jwt-Token'",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer"
                    });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        },
                        new string[] { }
                    }
                });
            });

            
            builder.Services.AddControllers();
            builder.Services.BusinessDependencyServices();
            builder.Services.DataDependencyServices();
            builder.Services.AddIdentity<User, IdentityRole<int>>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders();
            builder.Services.AddAutoMapper(typeof(Program));
            var jwtoptions = builder.Configuration.GetSection("Jwt").Get<JwtOption>();
            builder.Services.AddSingleton(jwtoptions);
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(
                    options =>
                    {

                        options.SaveToken = true;
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidateIssuer = true,
                            ValidIssuer = jwtoptions.Issuer,
                            ValidateAudience = true,
                            ValidAudience = jwtoptions.Audience,
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtoptions.SigningKey))
                        };

                    });
            builder.Services.AddAuthorization(
                options =>
                {
                    options.AddPolicy("Manager",
                       policy => policy.RequireClaim(ClaimTypes.Name, "Admin"));
                    options.AddPolicy("Vendor",
                       policy => policy.RequireClaim(ClaimTypes.Name,  "Vendor"));
                    options.AddPolicy("Client",
                       policy => policy.RequireClaim(ClaimTypes.Name,  "Client"));
                    options.AddPolicy("User",
                       policy => policy.RequireClaim(ClaimTypes.Name, "User"));
                });

            builder.Services.AddCors(options =>
                {
                    options.AddPolicy("AllowAll",
                        policyBuilder =>
                        {
                            policyBuilder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                        });
                });


                builder.Services.AddDbContext<AppDbContext>(OptionsBuilder =>
                {
                    OptionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
                        , b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
                });
                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.UseCors("AllowAll");

                app.UseAuthentication();

                app.UseAuthorization();

                app.MapControllers();

                app.Run();
        }
    }

    
}
