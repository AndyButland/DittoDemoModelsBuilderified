using UmbracoMapperified.Web.Infrastructure.IoC;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

namespace UmbracoMapperified.Web.Infrastructure.IoC
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon
    {
        #region Fields

        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        private static IKernel _kernel;

        #endregion

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
            _kernel = Bootstrapper.Kernel;
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }

        /// <summary>
        /// Gets an instance of the service matching the specified type arguments
        /// </summary>
        /// <typeparam name="T">Type of the service to retrieve</typeparam>
        /// <returns>An instance of a service bound to T, or default(T) 
        /// if no such binding exists</returns>
        public static T GetBinding<T>()
        {
            try
            {
                return _kernel.Get<T>();
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        /// <summary>
        /// Gets an instance of each service matching the specified type arguments
        /// </summary>
        /// <typeparam name="T">Type of the service(s) to retrieve</typeparam>
        /// <returns>An instance of a service bound to T, or null 
        /// if no such binding exists</returns>
        public static IEnumerable<T> GetAllBindings<T>()
        {
            try
            {
                return _kernel.GetAll<T>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets an instance of the specified service
        /// </summary>
        /// <typeparam name="T">Type of the service to retrieve</typeparam>
        /// <param name="name">Name that the binding was registered with</param>
        /// <returns>An instance of a service bound to T, or default(T) 
        /// if no such binding exists</returns>
        public static T GetNamedBinding<T>(string name)
        {
            try
            {
                return _kernel.Get<T>(name);
            }
            catch (ActivationException)
            {
                return default(T);
            }
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel(new NinjectServicesModule());
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }
    }
}
