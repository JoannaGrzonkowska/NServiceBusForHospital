using Autofac;
using RepositoryClasses;
using RtgBusinessLogic.Services;
using RtgDataAccess;
using RtgDataAccess.Repositories;

namespace RtgDependencyResolver
{
    public class RtgBusinessLogicModel : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var context = new KSR_RtgEntities();
            
            var unitOfWork = new UnitOfWork(context);
            var examinationsRepository = new ExaminationsRepository(context, unitOfWork);

            builder.RegisterInstance<IUnitOfWork>(unitOfWork);
            builder.RegisterInstance<IExaminationsRepository>(examinationsRepository);

            builder.RegisterInstance<IExaminationsService>(new ExaminationsService(examinationsRepository));

            base.Load(builder);
        }
    }
}
