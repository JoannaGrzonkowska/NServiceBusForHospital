using Autofac;
using BusinessLogic.Services;
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
            builder.RegisterType<PatientService>().As<IPatientService>().InstancePerRequest();
    
            base.Load(builder);
        }
    }
}

