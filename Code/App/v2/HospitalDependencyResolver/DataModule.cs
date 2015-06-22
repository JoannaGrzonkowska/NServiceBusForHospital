using Autofac;

namespace HospitalDependencyResolver
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.Register(c => new HospitalKSREntities()).As<HospitalKSREntities>().InstancePerRequest();

            //builder.RegisterType<PatientsRepository>().As<IPatientsRepository>().InstancePerRequest();
           // builder.RegisterType<DieseasesRepository>().As<IDieseasesRepository>().InstancePerRequest();
            //builder.RegisterType<PatientsDieseasesRepository>().As<IPatientsDieseasesRepository>().InstancePerRequest();

            //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            base.Load(builder);
        }
    }
}
