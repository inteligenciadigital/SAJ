using System.Web.Http;
using InteligenciaDigital.SAJ.Domain.Interfaces;
using InteligenciaDigital.SAJ.Repository;
using InteligenciaDigital.SAJ.Repository.Entity;
using InteligenciaDigital.SAJ.Repository.Interfaces;
using InteligenciaDigital.SAJ.Repository.Repositories;
using InteligenciaDigital.SAJ.Service;
using InteligenciaDigital.SAJ.Service.Interfaces;
using InteligenciaDigital.SAJ.Service.Services;

[assembly: WebActivator.PreApplicationStartMethod(typeof(InteligenciaDigital.SAJ.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(InteligenciaDigital.SAJ.Web.App_Start.NinjectWebCommon), "Stop")]

namespace InteligenciaDigital.SAJ.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);

            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IDataContext>().To<DataContext>().InRequestScope();
            kernel.Bind<IDatabaseFactory>().To<DatabaseFactory>().InRequestScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();

            kernel.Bind<IServidorTEFService>().To<ServidorTEFService>().InRequestScope();
            kernel.Bind<IServidorTEFRepository>().To<ServidorTEFRepository>().InRequestScope();
        }        
    }
}
