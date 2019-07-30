using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Business;
using ECommerce.Data;
using ECommerce.Service;
using ECommerce.Service.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using Swashbuckle.AspNetCore.Swagger;

namespace ECommerce.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

      public void DependencyInjection(IServiceCollection services) {
            #region repository
            services.AddSingleton<IClientRepository, ClientRepository>();
            services.AddSingleton<IOrderItensRepository, OrderItensRepository>();
            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<IProductTypeRepository, ProductTypeRepository>();
            #endregion repository

            #region business
            services.AddSingleton<IClientBusiness, ClientBusiness>();
            services.AddSingleton<IOrderItensBusiness, OrderItensBusiness>();
            services.AddSingleton<IOrderBusiness, OrderBusiness>();
            services.AddSingleton<IProductBusiness, ProductBusiness>();
            services.AddSingleton<IProductTypeBusiness, ProductTypeBusiness>();
            #endregion business

            #region service
            services.AddSingleton<IClientService, ClientService>();
            services.AddSingleton<IOrderItensService, OrderItensService>();
            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IProductTypeService, ProductTypeService>();
            #endregion business
        }

        public void ConfigureServices(IServiceCollection services) {
            DependencyInjection(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1",
                    new Info {
                        Title = "ECommerce",
                        Version = "v1",
                        Description = "...",
                        Contact = new Contact {
                            Name = "name - name",
                            Url = "https://github.com/fernandosp/ECommerce"
                        }
                    });

                var caminhoAplicacao =
                    PlatformServices.Default.Application.ApplicationBasePath;
                var nomeAplicacao =
                    PlatformServices.Default.Application.ApplicationName;
                var caminhoXmlDoc =
                    Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                c.IncludeXmlComments(caminhoXmlDoc);
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseHsts();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "ECommerce");
            });
        }
    }
}
