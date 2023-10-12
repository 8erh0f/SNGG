//using Microsoft.AspNetCore.Builder;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.OpenApi.Models;
//using SNGG.DataAccess;
//using SNGG.Services;
//using SNGG.Web.Data;

//namespace SNGG.Web
//{
//    public class Startup
//    {
//        private readonly IConfiguration _configuration;
//        private readonly IWebHostEnvironment _webHostingenv;

//        public Startup(IConfiguration configuration, IWebHostEnvironment webHostingenv)
//        {
//            _configuration = configuration;
//            _webHostingenv = webHostingenv;
//        }

//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.AddRazorPages();
//            services.AddServerSideBlazor();

//            services.AddEndpointsApiExplorer();
//            services.AddSwaggerGen(options =>
//            {
//                options.SwaggerDoc("v1", new OpenApiInfo { Title = "SNGG APIs", Version = "v1" });
//            });
//            services.AddControllers();
//            // Required for HttpClient support in the Blazor Client project
//            services.AddHttpClient();
//            // Pass settings to other components
//            services.AddSingleton(_configuration);

//            services.AddSingleton<WeatherForecastService>();
//            services.AddSingleton<ICheckGuessService, CheckGuessService>();
//            services.AddSingleton<ICalculateService, CalculateService>();

//            var SNGGonnectionstring = _configuration["ConnectionStrings:SNGGDbConnectionString"];
//            services.AddDbContextFactory<SNGGContext>(options =>
//            options.UseSqlServer(SNGGonnectionstring,
//            options => options.MinBatchSize(1).CommandTimeout(3600).MaxBatchSize(100).EnableRetryOnFailure(3))
//            , ServiceLifetime.Singleton);
//        }
//        public void Configure(IApplicationBuilder app)
//        {
//            // Configure the HTTP request pipeline.
//            if (!_webHostingenv.IsDevelopment())
//            {
//                app.UseExceptionHandler("/Error");
//                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//                app.UseHsts();
//            }

//            app.UseHttpsRedirection();

//            app.UseStaticFiles();
//            app.UseSwagger();
//            app.UseSwaggerUI();
//            app.UseRouting();

//            //app.MapBlazorHub();
//            //app.MapFallbackToPage("/_Host");

//            app.UseCors("AllowAll");

//            app.ConfigureEndpoints();
//            app.Run();
//        }
//    }
//}
