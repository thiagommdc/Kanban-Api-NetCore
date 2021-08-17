using BancoDados;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Dominio;
using Microsoft.OpenApi.Models;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "kanban", Version = "v1" });
            });

            services.AddDbContext<Contexto>(a =>
            a.UseSqlite(Configuration.GetConnectionString("ConexaoSQLite"), b => b.MigrationsAssembly("Api"))
            );

            var mappingconfig = new MapperConfiguration(
               mc => mc.AddProfile(new MappinProfile())
           );
            IMapper mapper = mappingconfig.CreateMapper();
            services.AddSingleton(mapper);

            new Dependencias(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "kanban"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(
               options => options.SetIsOriginAllowed(x => _ = true)
               .AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
