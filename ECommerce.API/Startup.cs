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

namespace ECommerce.API
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
            DependencyInjection(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void DependencyInjection(IServiceCollection services)
        {
            //var conn = this.Configuration.GetConnectionString("DefaultConnection");

            //var clientRepository = new ClientRepository(Configuration);

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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
