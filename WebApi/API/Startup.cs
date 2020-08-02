namespace API
{
    using AutoMapper;
    using Base.Datos.Clases.DAL;
    using Base.Datos.Contexto;
    using Base.Negocio.BL;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<Contexto>(options => options.UseSqlServer(Configuration.GetConnectionString("AppConnection")));

            //Cliente
            services.AddScoped<ClienteDAL>();
            services.AddScoped<ClienteBL>();
            //Compra
            services.AddScoped<CompraDAL>();
            services.AddScoped<CompraBL>();
            //InventarioProducto
            services.AddScoped<InventarioProductoDAL>();
            services.AddScoped<InventarioProductoBL>();
            //ProductoCompraCliente
            services.AddScoped<ProductoCompraClienteBL>();
            services.AddScoped<ProductoCompraClienteDAL>();
            //Producto
            services.AddScoped<ProductoDAL>();
            services.AddScoped<ProductoBL>();


            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}