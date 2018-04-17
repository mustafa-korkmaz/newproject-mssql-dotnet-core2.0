using AutoMapper;
using Business.Post;
using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Security;
using Security.Jwt;
using Services.Email;
using Services.Logging;
using Swashbuckle.AspNetCore.Swagger;
using WebApi.Middlewares;

namespace WebApi
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
            //services.AddDbContext<DaoContext>(options =>
            //{
            //    options.UseMySql(Configuration.GetConnectionString("DefaultConnection"));
            //});


            //Injecting the db context
            services.AddDbContext<Dal.BlogDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Injecting the identity manager
            services.AddIdentity<Dal.Models.Identity.ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<Dal.BlogDbContext>();
            //.AddDefaultTokenProviders();

            // Add functionality to inject IOptions<T>
            services.AddOptions();
            // Add our Config object so it can be injected
            services.Configure<AppSettings>(Configuration.GetSection("Keys"));

            //Injecting the repositories
            services.AddTransient<IPostBusiness, PostBusiness>();
            services.AddTransient<ISecurity, JwtSecurity>();

            // Add application services.
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ILogService, LogService>();
            services.AddAutoMapper();

            services.AddCors(config =>
            {
                var policy = new CorsPolicy();
                policy.Headers.Add("*");
                policy.Methods.Add("*");
                policy.Origins.Add("*");
                policy.SupportsCredentials = true;
                config.AddPolicy("policy", policy);
            });

            services.ConfigureJwtAuthentication();
            services.ConfigureJwtAuthorization();

            services.AddSwaggerGen(c =>
               {
                   c.SwaggerDoc("v1", new Info { Title = "My dot-net core api", Version = "v1" });
               });


            //All pages needs to be authenticated
            services.AddMvc(config =>
                {
                    var policy = new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .Build();
                    config.Filters.Add(new AuthorizeFilter(policy));
                })
                //add snake_case json convention
                .AddJsonOptions(x =>
                {
                    x.SerializerSettings.ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy
                        {
                            ProcessDictionaryKeys = true
                        }
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                context.Request.EnableRewind();
                await next();
            });

            //request handling
            app.UseRequestMiddleware();

            app.UseCors("policy");
            app.UseAuthentication();
            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
