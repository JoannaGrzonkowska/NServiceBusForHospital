using Autofac;
using RepositoryClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardBusinessLogic.Services;
using WardDataAccess;
using WardDataAccess.Repositories;

namespace WardDependencyResolver
{
    public class WardBusinessLogicModel : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var context = new KSR_WardEntities();
            
            var unitOfWork = new UnitOfWork(context);
            var patientsRepository = new PatientsRepository(context, unitOfWork);
            var patientsDieseasesRepository = new PatientsDieseasesRepository(context, unitOfWork);
            var examinationsRepository = new ExaminationsRepository(context, unitOfWork);
            var directorMessagesRepository = new DirectorMessagesRepository(context, unitOfWork);

            builder.RegisterInstance<IUnitOfWork>(unitOfWork);
            builder.RegisterInstance<IPatientsRepository>(patientsRepository);
            builder.RegisterInstance<IPatientsDieseasesRepository>(patientsDieseasesRepository);
            builder.RegisterInstance<IExaminationsRepository>(examinationsRepository);
            builder.RegisterInstance<IDirectorMessagesRepository>(directorMessagesRepository);

            builder.RegisterInstance<IPatientsService>(new PatientsService(patientsRepository));
            var patientsDieseasesService = new PatientsDieseasesService(patientsDieseasesRepository);
            builder.RegisterInstance<IPatientsDieseasesService>(patientsDieseasesService);
            builder.RegisterInstance<IExaminationsService>(new ExaminationsService(examinationsRepository, patientsDieseasesService));
            builder.RegisterInstance<IDirectorMessagesService>(new DirectorMessagesService(directorMessagesRepository));
            base.Load(builder);
        }
    }
}
