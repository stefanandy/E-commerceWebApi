using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TuringEcommerce.Models;
using TuringEcommerce.Services;
using TuringEcommerce.Services.Interfaces;

namespace TuringEcommerce
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
            services.AddDbContext<TuringContext>(options =>
                options.UseMySql(Configuration["ConnectionStrings:DefaultConnection"],
                    x => x.ServerVersion("8.0.16-mysql")));
            services.AddControllers();
            services.AddScoped<IDepartmentServices, DepartamentServices>();
            services.AddScoped<ICategoriesServices, CategorysServices>();
            services.AddScoped<IAttributesServices, AttributesServices>();
            services.AddScoped<ICustomerServices, CustomerServices>();
            services.AddScoped<IOrdersServices, OrderServices>();
            services.AddScoped<IProductsServices, ProductServices>();
            services.AddScoped<IShippingServices, ShippingService>();
            services.AddScoped<IShoppingCartServices, ShoppingCartServices>();
            services.AddScoped<ITaxServices, TaxService>();
            
            services.AddScoped<IPasswordHasher,PasswordHasher>();
            services.AddScoped<IStripeServices, StripeServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}