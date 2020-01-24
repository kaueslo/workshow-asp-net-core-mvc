using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using VendasWebMVC.Models;
using VendasWebMVC.Data;
using VendasWebMVC.Services;

namespace VendasWebMVC
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
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});


			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

		    services.AddDbContext<VendasWebMVCContext>(options =>
					options.UseMySql(Configuration.GetConnectionString("VendasWebMVCContext"), builder => builder.MigrationsAssembly("VendasWebMVC")));

			//Colocando a classe seedingservice para preencher os dados automáticamente
			services.AddScoped<Seedingservice>();
			services.AddScoped<ServicoVendedor>();
			services.AddScoped<ServicoDepartamento>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, Seedingservice seedingservice)
		{

			var ptBr = new CultureInfo("pt-BR");

			var opcaoLocal = new RequestLocalizationOptions
			{
				DefaultRequestCulture = new RequestCulture(ptBr),
				SupportedCultures = new List<CultureInfo> { ptBr },
				SupportedUICultures = new List<CultureInfo> { ptBr }
			};

			app.UseRequestLocalization(opcaoLocal);


			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				seedingservice.Seed();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
