using Autofac;
using DirectorBusinessLogic.Services;
using DirectorDataAccess;
using DirectorDataAccess.Repositories;
using RepositoryClasses;

namespace DirectorDependencyResolver
{
    public class DirectorBusinessLogicModel : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var context = new KSR_DirectorEntities();
            
            var unitOfWork = new UnitOfWork(context);
            var examinationsRepository = new DirectorMessagesRepository(context, unitOfWork);

            builder.RegisterInstance<IUnitOfWork>(unitOfWork);
            builder.RegisterInstance<IDirectorMessagesRepository>(examinationsRepository);

            builder.RegisterInstance<IDirectorMessagesService>(new DirectorMessagesService(examinationsRepository));

            base.Load(builder);
        }
    }
}
