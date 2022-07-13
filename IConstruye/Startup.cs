
using IConstruye.Api.Filters;
using IConstruye.Api.Options;

using System.Diagnostics.CodeAnalysis;
using IConstruye.Utils.Swagger;
using IConstruye.Dtos;
using IConstruye.Contract;
using IConstruye.Business;
using IConstruye.Api.Business;

namespace IConstruye.Api
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                InternalErrorsOptions internalErrorsOptions = Configuration.GetSection(InternalErrorsOptions.SettingName).Get<InternalErrorsOptions>();
                if (internalErrorsOptions.Hidden)
                {
                    options.Filters.Add(typeof(InternalErrorExceptionFilter));
                }
            });

            services.AddSwaggerExtension(Configuration);
            services.AddHealthChecks();
            services.AddMvcCore().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });

            services.AddScoped<InternalErrorExceptionFilter>();

    
            services.AddScoped<ICatalogBaseBusiness<ProductDto>, ProductBusiness>();
            services.AddScoped<ICatalogBaseBusiness<SaleDto>, SaleBusiness>();
  

            services.AddScoped<IProductContract, ProductBusiness>();
            services.AddScoped<ISaleContract, SaleBusiness>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwaggerExtension(Configuration);

            app.UseHealthChecks("/health");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
