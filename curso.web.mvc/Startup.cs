using curso.web.mvc.Handlers;
using curso.web.mvc.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace curso.web.mvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();

            var clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };

            services.AddRefitClient<IUsuarioService>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri(Configuration.GetValue<string>("UrlApiCurso"));
                }).ConfigurePrimaryHttpMessageHandler(c => clientHandler);

            services.AddTransient<BearerTokenMessageHandler>();

            services.AddRefitClient<ICursoService>()
                .AddHttpMessageHandler<BearerTokenMessageHandler>()
               .ConfigureHttpClient(c =>
               {
                   c.BaseAddress = new Uri(Configuration.GetValue<string>("UrlApiCurso"));
               }).ConfigurePrimaryHttpMessageHandler(c => clientHandler);

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
           .AddCookie(options =>
           {
               options.LoginPath = "/Usuario/Logar";
               options.AccessDeniedPath = "/Usuario/Logar";
           });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
