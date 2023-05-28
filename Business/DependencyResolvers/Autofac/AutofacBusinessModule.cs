using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Biri bizden ICarsService isterse ise Instance olarak CarsManager ı ver. SingleInstance ise tek bir tane instance oluşturur.
            builder.RegisterType<CarsManager>().As<ICarsService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarsDal>().SingleInstance();
            builder.RegisterType<BrandsManager>().As<IBrandsService>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandsDal>().SingleInstance();
            builder.RegisterType<ColorsManager>().As<IColorsService>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorsDal>().SingleInstance();
            builder.RegisterType<CustomersManager>().As<ICustomersService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomersDal>().SingleInstance();
            builder.RegisterType<UsersManager>().As<IUsersService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUsersDal>().SingleInstance();
            builder.RegisterType<RentalsManager>().As<IRentalsService>().SingleInstance();
            builder.RegisterType<EfRentalDal>().As<IRentalsDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
