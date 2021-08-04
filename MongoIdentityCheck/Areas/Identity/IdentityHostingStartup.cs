using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoIdentityCheck.Areas.Identity.Data;
using MongoIdentityCheck.Data;

[assembly: HostingStartup(typeof(MongoIdentityCheck.Areas.Identity.IdentityHostingStartup))]
namespace MongoIdentityCheck.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                //services.AddDbContext<MongodbContext>(options =>
                //    options.UseSqlServer(
                //        context.Configuration.GetConnectionString("MongodbContextConnection")));

                //services.AddDefaultIdentity<MongodbUser>(options => options.SignIn.RequireConfirmedAccount = true)
                //    .AddEntityFrameworkStores<MongodbContext>();
            });
        }
    }
}