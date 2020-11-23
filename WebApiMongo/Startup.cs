using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnWebApiMongo.Models;
using LearnWebApiMongo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LearnWebApiMongo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // requires using Microsoft.Extensions.Options
            //services.Configure<BookstoreDatabaseSettings>(
            //    Configuration.GetSection(nameof(BookstoreDatabaseSettings)));

            //services.AddSingleton<IBookstoreDatabaseSettings>(sp =>
            //    sp.GetRequiredService<IOptions<BookstoreDatabaseSettings>>().Value);

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("_myAllowSpecificOrigins",
            //    builder =>
            //    {
            //        builder.AllowAnyOrigin()
            //                .AllowAnyMethod()
            //                .AllowAnyHeader()
            //                .AllowCredentials();
            //    });
            //});
            services.AddCors();
            services.Configure<RestaDatabaseSettings>(
                Configuration.GetSection(nameof(RestaDatabaseSettings)));

            services.AddSingleton<IRestaDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<RestaDatabaseSettings>>().Value);

            //services.AddSingleton<BookService>();
            services.AddSingleton<SurveyService>();
            services.AddSingleton<AnswerService>();
            
            services.AddControllers().AddNewtonsoftJson(options => options.UseMemberCasing());
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
