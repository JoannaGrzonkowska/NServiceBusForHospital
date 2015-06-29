using Autofac;
using BusinessLogic.CommandHandlers;
using BusinessLogic.Services;
using DataAccess;
using DataAccess.Repositories;

namespace HospitalDependencyResolver
{
    public class BusinessLogicModel : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var context = new HospitalKSREntities();
            var unitOfWork = new UnitOfWork(context);
            
            var patientsRepository = new PatientsRepository(context);
            var dieseasesRepository = new DieseasesRepository(context);
            var patientsDieseasesRepository = new PatientsDieseasesRepository(context);
            var examinationsRepository = new ExaminationsRepository(context);
            var directorMessagesRepository = new DirectorMessagesRepository(context, unitOfWork);
            builder.RegisterInstance<IDirectorMessagesRepository>(directorMessagesRepository);

            builder.RegisterInstance<IPatientsRepository>(patientsRepository);
            builder.RegisterInstance<IDieseasesRepository>(dieseasesRepository);
            builder.RegisterInstance<IPatientsDieseasesRepository>(patientsDieseasesRepository);
            builder.RegisterInstance<IExaminationsRepository>(examinationsRepository);

            builder.RegisterInstance<IUnitOfWork>(unitOfWork);

            var patientService = new PatientsService(patientsRepository);
            var addPatientCommandHandler = new AddPatientCommandHandler(patientsRepository,unitOfWork);
            builder.RegisterInstance<IPatientsService>(patientService);
            builder.RegisterInstance<IAddPatientCommandHandler>(addPatientCommandHandler);
            builder.RegisterInstance<IDieseasesService>(new DieseasesService(dieseasesRepository));
            builder.RegisterInstance<IPatientsDieseasesService>(new PatientsDieseasesService(patientsDieseasesRepository));
            builder.RegisterInstance<IAccountService>(new AccountService(patientService, addPatientCommandHandler));
            builder.RegisterInstance<IExaminationsService>(new ExaminationsService(examinationsRepository));
            builder.RegisterInstance<IDirectorMessagesService>(new DirectorMessagesService(directorMessagesRepository));
     
            builder.RegisterInstance<IAddDieseaseToPatientCommandHandler>(new AddDieseaseToPatientCommandHandler(patientsDieseasesRepository, unitOfWork));
            builder.RegisterInstance<IAddExaminationToPatientCommandHandler>(new AddExaminationToPatientCommandHandler(examinationsRepository, unitOfWork));
       
            base.Load(builder);
        }
    }
}
