using FitnessBackend.Services;
using FitnessBackend.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FitnessBackend
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
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                }));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FitnessBackend", Version = "v1" });
            });
            services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            services.AddTransient<ICityCollectionService, CityCollectionService>();
            services.AddTransient<IGymCollectionService, GymCollectionService>();            
            services.AddTransient<IGymDescriptionCollectionService, GymDescriptionCollectionService>();
            services.AddTransient<IGymPricesCollectionService, GymPricesCollectionService>();
            services.AddTransient<IGymOpenHoursCollectionService, GymOpenHoursCollectionService>();
            services.AddTransient<IGymScheduleCollectionService, GymScheduleCollectionService>();
            services.AddTransient<IGymTrainersCollectionService, GymTrainersCollectionService>();
            services.AddTransient<IGymTrainingsCollectionService, GymTrainingsCollectionService>();
            services.AddTransient<IReservationCollectionService, ReservationCollectionService>();

            //city
            services.Configure<MongoDBSettings>(Configuration.GetSection(nameof(MongoDBSettings)));
            services.AddSingleton<IMongoDBSettings>(sp => sp.GetRequiredService<IOptions<MongoDBSettings>>().Value);

            //gym
            services.Configure<MongoDBSettingsGym>(Configuration.GetSection(nameof(MongoDBSettingsGym)));
            services.AddSingleton<IMongoDBSettingsGym>(sp => sp.GetRequiredService<IOptions<MongoDBSettingsGym>>().Value);

            //gym-description
            services.Configure<MongoDBSettingsGymDescription>(Configuration.GetSection(nameof(MongoDBSettingsGymDescription)));
            services.AddSingleton<IMongoDBSettingsGymDescription>(sp => sp.GetRequiredService<IOptions<MongoDBSettingsGymDescription>>().Value);

            //gym-prices
            services.Configure<MongoDBSettingsGymPrices>(Configuration.GetSection(nameof(MongoDBSettingsGymPrices)));
            services.AddSingleton<IMongoDBSettingsGymPrices>(sp => sp.GetRequiredService<IOptions<MongoDBSettingsGymPrices>>().Value);

            //gym-open-hours
            services.Configure<MongoDBSettingsGymOpenHours>(Configuration.GetSection(nameof(MongoDBSettingsGymOpenHours)));
            services.AddSingleton<IMongoDBSettingsGymOpenHours>(sp => sp.GetRequiredService<IOptions<MongoDBSettingsGymOpenHours>>().Value);

            //gym-schedule
            services.Configure<MongoDBSettingsGymSchedule>(Configuration.GetSection(nameof(MongoDBSettingsGymSchedule)));
            services.AddSingleton<IMongoDBSettingsGymSchedule>(sp => sp.GetRequiredService<IOptions<MongoDBSettingsGymSchedule>>().Value);

            //gym-trainers
            services.Configure<MongoDBSettingsGymTrainers>(Configuration.GetSection(nameof(MongoDBSettingsGymTrainers)));
            services.AddSingleton<IMongoDBSettingsGymTrainers>(sp => sp.GetRequiredService<IOptions<MongoDBSettingsGymTrainers>>().Value);

            //gym-trainings
            services.Configure<MongoDBSettingsGymTrainings>(Configuration.GetSection(nameof(MongoDBSettingsGymTrainings)));
            services.AddSingleton<IMongoDBSettingsGymTrainings>(sp => sp.GetRequiredService<IOptions<MongoDBSettingsGymTrainings>>().Value);

            //reservation
            services.Configure<MongoDBSettingsReservation>(Configuration.GetSection(nameof(MongoDBSettingsReservation)));
            services.AddSingleton<IMongoDBSettingsReservation>(sp => sp.GetRequiredService<IOptions<MongoDBSettingsReservation>>().Value);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("CorsPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FitnessBackend V1");
                c.RoutePrefix = string.Empty;
            });


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
