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
        //server ile ilgili konfig�rasyonun oldu�u yer...
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
// }) 'yi kullanarak, .NET'e kendi IoC yap�n� kullanma, fabrika olarak Autofac'i kullan diyoruz.
//.ConfigureContainer'a Autofac'in konumunu verdik.
//G�z�n�z korkmas�n. Bunlar�n s�ralan���n� hocada ezbere bilmiyor doc'a bak�p �yle yaz�yor.

//Diyelim ki yar�n bir g�n Autofac'ten vazge�mek istersek, ba�ka bir yap� kullanmak istersek.
//Yapaca��m�z i�lem: DependencyResolvers'da yeni yap� kurmak ve burada yani Program.cs'deki new'leri de�i�tirmek.Sadece bu!