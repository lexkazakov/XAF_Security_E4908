﻿using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Net.Http;
using System.Threading.Tasks;
using XafSolution.Module.BusinessObjects;

namespace BlazorClientSideApplication {
    public class Program {
        public static async Task Main(string[] args) {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped(UoW => XpoHelper.CreateUnitOfWork());

            builder.Services.AddDevExpressBlazor();
            await XpoHelper.InitXpo(WebApiDataStoreClient.GetConnectionString("https://127.0.0.1:44327/xpo/"), "Admin", "");
            await builder.Build().RunAsync();
        }
    }
}
