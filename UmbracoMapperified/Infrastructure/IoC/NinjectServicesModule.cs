namespace TxtStarter.Infrastructure.IoC
{
    using Ninject.Extensions.Conventions;
    using Ninject.Modules;
    using Ninject.Web.Common;
    using TxtStarter.Infrastructure.Handlers;
    using TxtStarter.Infrastructure.ViewModelBuilder;
    using Zone.UmbracoMapper;

    public class NinjectServicesModule : NinjectModule
    {
        public override void Load()
        {
            var webDll = typeof(NinjectServicesModule).Assembly.ManifestModule.Name;

            // Configure container with each of the typed handler variations
            Kernel.Bind(x => x
               .FromAssembliesMatching(webDll)
               .SelectAllClasses().InheritedFrom(typeof(IHandler<,,>))
               .BindAllInterfaces()
               .Configure(y => y.InRequestScope()));

            Kernel.Bind(x => x
                .FromAssembliesMatching(webDll)
                .SelectAllClasses().InheritedFrom(typeof(IHandler<,>))
                .BindAllInterfaces()
                .Configure(y => y.InRequestScope()));

            Kernel.Bind(x => x
                .FromAssembliesMatching(webDll)
                .SelectAllClasses().InheritedFrom(typeof(IHandler<>))
                .BindAllInterfaces()
                .Configure(y => y.InRequestScope()));

            Kernel.Bind<IViewModelBuilder>().To<ViewModelBuilder>();
            Kernel.Bind<IHandlerResolver>().To<HandlerResolver>();
            Kernel.Bind<IUmbracoMapper>().To<UmbracoMapper>();
        }
    }
}
