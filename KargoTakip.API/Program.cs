using System.Text.Json.Serialization;
using KargoTakip.Business.Abstract;
using KargoTakip.Business.Concrete;
using KargoTakip.Core.DTO;
using KargoTakip.DAL.Abstract;
using KargoTakip.DAL.Concrete;
using KargoTakip.DAL.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

namespace KargoTakip.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpContextAccessor();

            var cBuilder = new ConfigurationBuilder();
            cBuilder.AddJsonFile("appsettings.json");
            IConfiguration configuration = cBuilder.Build();
            var connString = configuration.GetConnectionString("KargoTakipDB");

            builder.Services.AddDbContext<KargoTakipContext>(options => options.UseSqlServer(connString));
            builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork>();

            builder.Services.AddScoped<IPersonelManager, PersonelManager>();
            builder.Services.AddScoped<IAdresManager, AdresManager>();
            builder.Services.AddScoped<IIlceManager, IlceManager>();
            builder.Services.AddScoped<IKargoManager, KargoManager>();
            builder.Services.AddScoped<IKargoDetayManager, KargoDetayManager>();
            builder.Services.AddScoped<IMusteriManager, MusteriManager>();
            builder.Services.AddScoped<ISubeManager, SubeManager>();
            builder.Services.AddScoped<IUcretManager, UcretManager>();
            builder.Services.AddScoped<IIslemTuruManager, IslemTuruManager>();
            builder.Services.AddScoped<ISehirManager, SehirManager>();
            builder.Services.AddScoped<IAccountManager, AccountManager>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
            builder.Services.Configure<JWTExceptURLList>(builder.Configuration.GetSection(nameof(JWTExceptURLList)));

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
        }
    }
}