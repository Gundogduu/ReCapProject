using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.AutoFac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        //server ile ilgili konfigürasyonun olduðu yer...
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule(new AutofacBusinessModule());
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
//.UseServiceProviderFactory(new AutofacServiceProviderFactory()
//.ConfigureContainer<ContainerBuilder>(builder =>
// {
//     builder.RegisterModule(new AutofacBusinessModule());
// }) 'yi kullanarak, .NET'e kendi IoC yapýný kullanma, fabrika olarak Autofac'i kullan diyoruz.
//.ConfigureContainer'a Autofac'in konumunu verdik.
//Gözünüz korkmasýn. Bunlarýn sýralanýþýný hocada ezbere bilmiyor doc'a bakýp öyle yazýyor.

//Diyelim ki yarýn bir gün Autofac'ten vazgeçmek istersek, baþka bir yapý kullanmak istersek.
//Yapacaðýmýz iþlem: DependencyResolvers'da yeni yapý kurmak ve burada yani Program.cs'deki new'leri deðiþtirmek.Sadece bu!