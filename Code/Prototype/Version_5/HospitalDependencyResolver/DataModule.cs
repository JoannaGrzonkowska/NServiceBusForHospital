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
           // builder.RegisterInstance(typeof(HospitalTestEntities), new HospitalTestEntities(), new H);

            builder.Register(c => new HospitalTestEntities()).As<HospitalTestEntities>().InstancePerRequest();
           

            builder.RegisterType<PatientRepository>().As<IPatientRepository>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            base.Load(builder);
        }
    }
}
