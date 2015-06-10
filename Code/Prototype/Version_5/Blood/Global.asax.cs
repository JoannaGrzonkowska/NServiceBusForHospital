using Autofac;
using Autofac.Integration.Mvc;
using HospitalDependencyResolver;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Blood
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
            //  GlobalConfiguration.Configure(WebApiConfig.Register);

            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);


            builder.RegisterModule(new DataModule());
            builder.RegisterModule(new BusinessLogicModel());

            // Set the dependency resolver to be Autofac.
            IContainer container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            /* GlobalConfiguration.Configuration.DependencyResolver =
     new AutofacWebApiDependencyResolver(container);*/



            BusConfiguration busConfiguration = new BusConfiguration();
            busConfiguration.EndpointName("BloodEndPoint");
            busConfiguration.UseSerialization<JsonSerializer>();
            busConfiguration.UseContainer<AutofacBuilder>(c => c.ExistingLifetimeScope(container));
            busConfiguration.UsePersistence<InMemoryPersistence>();
            busConfiguration.EnableInstallers();

            var startableBus = Bus.Create(busConfiguration);
            bus = startableBus.Start();


            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
