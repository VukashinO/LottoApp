using BusinessLayer;
using BusinessLayer.CreateRound;
using BusinessLayer.Tickets;
using DataLayer.Round;
using DataLayer.Tickets;
using DataLayer.Users;
using DomainModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LottoApp
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
            services.AddTransient<IUserService, UserService>();
            services.AddTransient <IUserRepository, UserRepository>();
            services.AddTransient<ITicketService, TicketService>();
            services.AddTransient<ITicketRepository, TicketRepository>();
            services.AddTransient<IRoundRepository, RoundRepository>();
            services.AddTransient<ICreateRound, CreateRound>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            const string connection = "Server=PETRA19;Database=LottoDB;user=Sa;password=Password1;";
            services.AddDbContext<LottoDbContext>
                (options => options.UseSqlServer(connection));
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
