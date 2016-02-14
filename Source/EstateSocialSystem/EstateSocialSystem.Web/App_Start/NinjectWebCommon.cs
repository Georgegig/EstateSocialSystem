[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(EstateSocialSystem.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(EstateSocialSystem.Web.App_Start.NinjectWebCommon), "Stop")]

namespace EstateSocialSystem.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Extensions.Conventions;
    using System.Data.Entity;
    using Data;
    using Data.Common.Repository;
    using Data.Models;

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
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IRepository<Estate>)).To(typeof(IDeletableEntityRepository<Estate>));
            kernel.Bind(typeof(IRepository<Appliance>)).To(typeof(IDeletableEntityRepository<Appliance>));
            kernel.Bind(typeof(IRepository<User>)).To(typeof(IDeletableEntityRepository<User>));

            kernel.Bind<DbContext>().To<EstateSocialSystemDbContext>();
            kernel.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));

            kernel.Bind(typeof(IDeletableEntityRepository<>))
                .To(typeof(DeletableEntityRepository<>));


            kernel.Bind(b => b.From("EstateSocialSystem.Services.Data")
                .SelectAllClasses()
                .BindDefaultInterface());

            kernel.Bind(b => b.From("EstateSocialSystem.Services.Web")
                .SelectAllClasses()
                .BindDefaultInterface());

            //kernel.Bind<ISanitizer>().To<HtmlSanitizerAdapter>();
        }        
    }
}
