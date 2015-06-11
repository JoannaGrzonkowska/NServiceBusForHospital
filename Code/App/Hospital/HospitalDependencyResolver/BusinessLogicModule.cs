using Autofac;
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
        /*    builder.RegisterType<PatientService>().As<IPatientService>().InstancePerRequest();
            builder.RegisterType<AlergyService>().As<IAlergyService>().InstancePerRequest();
            builder.RegisterType<PatientAlergyService>().As<IPatientAlergyService>().InstancePerRequest();
            builder.RegisterType<AccountService>().As<IAccountService>().InstancePerRequest();

            builder.RegisterType<AddPatientCommandHandler>().As<IAddPatientCommandHandler>().InstancePerRequest();
            builder.RegisterType<AddAlergyToPatientCommandHandler>().As<IAddAlergyToPatientCommandHandler>().InstancePerRequest();
            */
            base.Load(builder);
        }
    }
}
