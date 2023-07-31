using Microsoft.EntityFrameworkCore;
using MusicApp.Service.Abstractions;
using MusicApp.Services;
using Persistence;
using Persistence.Repositories;
using Persistence.Repository.Abstractions;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
namespace MusicApp
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
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("MusicContext");
                options.UseSqlServer(connectionString);
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            //builder.Services.AddScoped<IGenreRepository, GenreRepository>();
            builder.Services.AddScoped<IGenreService, GenreService>();
            builder.Services.AddScoped<IArtistService, ArtistService>();
            builder.Services.AddScoped<ISongService, SongService>();
            builder.Services.AddScoped<IAlbumService, AlbumService>();
            builder.Services.AddAutoMapper(typeof(Contracts.AssemblyReference).Assembly);
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