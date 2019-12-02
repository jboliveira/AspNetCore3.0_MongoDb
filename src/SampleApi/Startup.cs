using System;
using System.Net.Mime;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SampleApi.Infrastructure;
using SampleApi.Services;

namespace SampleApi
{
	public class Startup
	{
		private readonly IConfiguration _configuration;

		public Startup(IConfiguration configuration)
		{
			_configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddOptions();
			services.Configure<MongoDbSettings>(_configuration.GetSection(nameof(MongoDbSettings)));
			services.AddTransient<IMongoDbSettings>(resolver => resolver.GetService<IOptionsMonitor<MongoDbSettings>>().CurrentValue);

			services.AddControllers()
				.AddMvcOptions(opt =>
				{
					opt.Filters.Add(new ProducesAttribute(MediaTypeNames.Application.Json));
					opt.Filters.Add(new ConsumesAttribute(MediaTypeNames.Application.Json));
				})
				.AddJsonOptions(opt =>
				{
					opt.JsonSerializerOptions.IgnoreNullValues = true;
					opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
				})
				.SetCompatibilityVersion(CompatibilityVersion.Latest)
				.AddControllersAsServices();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
			});

			RegisterServices(services);
		}

		// .NET Native DI
		private static void RegisterServices(IServiceCollection services)
		{
			services.AddScoped<ISampleService, SampleService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
			});

			app.UseHttpsRedirection();
			app.UseAuthorization();
			app.UseStaticFiles();
			app.UseRouting();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
