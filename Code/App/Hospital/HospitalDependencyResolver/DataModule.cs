using Autofac;
using DataAccess;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDependencyResolver
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new HospitalKSREntities()).As<HospitalKSREntities>().InstancePerRequest();

            builder.RegisterType<PatientsRepository>().As<IPatientsRepository>().InstancePerRequest();
            builder.RegisterType<DieseasesRepository>().As<IDieseasesRepository>().InstancePerRequest();
            builder.RegisterType<PatientsDieseasesRepository>().As<IPatientsDieseasesRepository>().InstancePerRequest();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            base.Load(builder);
        }
    }
}
