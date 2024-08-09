using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Helpers.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dependency.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AboutMeManager>().As<IAboutMeService>().SingleInstance();   
            builder.RegisterType<EfAboutMeDal>().As<IAboutMeDal>().SingleInstance();

            builder.RegisterType<TravelManager>().As<ITravelService>().SingleInstance(); 
            builder.RegisterType<EFTravelDal>().As<ITravelDal>().SingleInstance();

            builder.RegisterType<TravelToCategoryManager>().As<ITravelToCategoryService>().SingleInstance(); 
            builder.RegisterType<EFTravelToCategory>().As<ITravelToCategoryDal>().SingleInstance();  
            
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();    
            builder.RegisterType<EFCategoryDal>().As<ICategoryDal>().SingleInstance();  

            builder.RegisterType<FaqPageManager>().As<IFaqService>().SingleInstance();  
            builder.RegisterType<EFFaqPageDal>().As<IFaqPageDal>().SingleInstance();    

            builder.RegisterType<AppDbContext>().As<AppDbContext>().SingleInstance();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
    }

