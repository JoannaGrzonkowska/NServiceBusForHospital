using Autofac;
using Autofac.Integration.Mvc;
using HospitalDependencyResolver;
using NServiceBus;
using RTG.Hubs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RTG
{
    public class MvcApplication : System.Web.HttpApplication
    {
        IBus bus;

        public override void Dispose()
        {
            if (bus != null)
            {
                bus.Dispose();
            }
            base.Dispose();
        }
        
        protected void Application_Start()
        {
            //New container from autofac
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterModule(new DataModule());
            builder.RegisterModule(new BusinessLogicModel());

            builder.RegisterInstance<IShowToUIHubService>(new ShowToUIHubService());            
            IContainer container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            //Configuration for szyna
            BusConfiguration busConfiguration = new BusConfiguration();
            busConfiguration.EndpointName("RTG_EndPoint");
            busConfiguration.UseSerialization<JsonSerializer>();
            busConfiguration.UseContainer<AutofacBuilder>(c => c.ExistingLifetimeScope(container));
            busConfiguration.UsePersistence<InMemoryPersistence>();
            busConfiguration.EnableInstallers();

            //Setting up and starting up Bus
            var startableBus = Bus.Create(busConfiguration);
            bus = startableBus.Start();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
