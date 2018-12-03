using InfinityLibrary.Database.Contexts;
using Microsoft.AspNetCore.Blazor.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Net.Mime;
using InfinityLibrary.Core.Providers;
using InfinityLibrary.Core.Repositories;
using InfinityLibrary.Database.Repositories;
using InfinityLibrary.Providers;

namespace InfinityLibrary.Server
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddResponseCompression(options =>
            {
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                {
                    MediaTypeNames.Application.Octet,
                    WasmMediaTypeNames.Application.Wasm,
                });
            });

            services.AddDbContext<InfinityDbContext>(options => options.UseSqlite("Data Source=InfinityLibrary.db"));

            // Repositories
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IBookRepository, BookRepository>();
            services.AddSingleton<IReservationRepository, ReservationRepository>();

            // Providers
            services.AddSingleton<IUserProvider, UserProvider>();
            services.AddSingleton<IBookProvider, BookProvider>();
            services.AddSingleton<IReservationProvider, ReservationProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller}/{action}/{id?}");
            });

            app.UseBlazor<Client.Startup>();
        }
    }
}
