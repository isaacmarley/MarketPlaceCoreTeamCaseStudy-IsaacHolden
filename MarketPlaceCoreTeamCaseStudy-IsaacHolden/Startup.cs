using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using DataLibrary.MongoSerializers;
using DataLibrary.Services.ApplicantResponses;
using DataLibrary.Services.ApplicantValidation;
using DataLibrary.Services.CreditCard;
using DataLibrary.Services.CreditCardResponse;
using DataLibrary.Services.Mongo;

namespace MarketPlaceCoreTeamCaseStudy_IsaacHolden
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MarketPlaceCoreTeamCaseStudy_IsaacHolden", Version = "v1" });
            });

            services.AddSingleton<ISerializers, Serializers>();
            services.AddTransient<ICreditCardService, CreditCardService>();
            services.AddTransient<ICreditCardResponseService, CreditCardResponseService>();
            services.AddTransient<IApplicantResponsesService, ApplicantResponsesService>();
            services.AddTransient<IApplicantValidationService, ApplicantValidationService>();
            services.AddTransient<IMongoClient, MongoClient>();
            services.AddTransient<IMongoContext, MongoContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MarketPlaceCoreTeamCaseStudy_IsaacHolden v1"));
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
