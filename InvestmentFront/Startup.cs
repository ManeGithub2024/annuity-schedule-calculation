using InvestmentFront.Domain.Entities;
using InvestmentFront.Domain.Services;
using InvestmentFront.Infrastructure.BUS;
using InvestmentFront.Infrastructure.BusinessLogic;
using InvestmentFront.Infrastructure.Data;
using InvestmentFront.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Globalization;

namespace InvestmentFront
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Automatically finds mapping profiles
            services.AddAutoMapper(typeof(Startup));

            // Infrastructure
            services.AddScoped<IRepository<Product>, ProductRepository>();
            services.AddScoped<IRepository<Loan>, LoanRepository>();
            services.AddScoped<IRepository<LoanRequest>, LoanRequestRepository>();
            services.AddScoped<IRepository<LoanTransaction>, LoanTransactionRepository>();
            services.AddScoped<IRangeCalculator, RangeCalculator>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICommandHandler, LoanRequestHandler>();
            services.AddScoped<ICommandHandler, LoanHandler>();
            services.AddScoped<ICommandHandler, LoanCalculationHandler>();
            services.AddScoped<ICommandBus, CommandBus>();
            services.AddScoped<ICalculationService, CalculationService>();

            services.AddMemoryCache();
            services.AddSession();

            // Instead of services.AddMvc();
            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();

            services.AddHttpContextAccessor();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Adjusting to the culture of Great Britain
            var gbCulture = new CultureInfo("en-GB");
            var localizationOptions = new RequestLocalizationOptions {
                DefaultRequestCulture = new RequestCulture(gbCulture),
                SupportedCultures = new List<CultureInfo> { gbCulture },
                SupportedUICultures = new List<CultureInfo> { gbCulture }
            };
            // to use the en-GB format for all requests
            app.UseRequestLocalization(localizationOptions);

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();

            } else {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts(); // Recommended for Enterprise (Security)
            }

            app.UseHttpsRedirection(); // The modern standard for all .NET applications
            app.UseStaticFiles();

            app.UseRouting(); // Modern routing

            app.UseSession(); // Middleware for Sessions

            app.UseEndpoints(endpoints => {
                // Route for mistakes
                endpoints.MapControllerRoute(
                    name: "Error",
                    pattern: "Error",
                    defaults: new { controller = "Error", action = "Error" });

                // Default route
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
