using Autofac;
using BusinessLogic.CommandHandlers;
using BusinessLogic.Services;
using DataAccess;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDependencyResolver
{
    public class BusinessLogicModel : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PatientsService>().As<IPatientsService>().InstancePerRequest();
            builder.RegisterType<DieseasesService>().As<IDieseasesService>().InstancePerRequest();
            builder.RegisterType<PatientsDieseasesService>().As<IPatientsDieseasesService>().InstancePerRequest();
            builder.RegisterType<AccountService>().As<IAccountService>().InstancePerRequest();

            builder.RegisterType<AddPatientCommandHandler>().As<IAddPatientCommandHandler>().InstancePerRequest();
            builder.RegisterType<AddDieseaseToPatientCommandHandler>().As<IAddDieseaseToPatientCommandHandler>().InstancePerRequest();

            var context = new HospitalKSREntities();
            var patientsRepository = new PatientsRepository(context);

            builder.RegisterInstance<IPatientsRepository>(patientsRepository);

            builder.RegisterInstance<IPatientsService>(new PatientsService(patientsRepository));
           

            base.Load(builder);
        }
    }
}
