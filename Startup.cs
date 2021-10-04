using EmployeeRestAPI.Data;
using EmployeeRestAPI.Entities;
using EmployeeRestAPI.Repositories;
using EmployeeRestAPI.Services;
using EmployeeRestAPI.Validation;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace EmployeeRestAPI
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
            services.AddDbContext<EmployeesContext>(d =>
                d.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            //Services
            services.AddTransient<EmployeeService>();
            services.AddTransient<CompanyService>();


            //AutoMapper
            services.AddAutoMapper(typeof(Startup));

            services.AddControllers().AddFluentValidation(fv =>
            {
                ////
                // Not sure which line is best.
                ////
                //fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false; 
                fv.DisableDataAnnotationsValidation = true;
                fv.RegisterValidatorsFromAssemblyContaining<Startup>();
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmployeeRestAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmployeeRestAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
