using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.AutoFac
{
    //sen artık Autofac modülüsün
    public class AutofacBusinessModule : Module
    { 
        protected override void Load(ContainerBuilder builder)
        {
            //bu işlemler startup da yaptığımızın aynısı!
            //birisi senden ICarServis'i isterse ona CarManager'ın instance'ını ver yani new'le.
            //SingleInstance: tek bir instance oluştur demek. Yani içinde data tutmadığını bildiğimiz için, sadece operasyonu çağırma,data taşıyor.
            //O yüzden tek bir instance oluştursun herkese onu versin, böylece düşünsenize 100bin kullanıcılı sistemde 1 gün içinde 100bin instance üretmek yerine 1 kere üretüyor ve onu herkesle paylaşıyor.Bunlar referans tip bellekteki aynı referans numarasını herkesle paylaşıyor.
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();
            builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();
            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();
            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
