using Autofac;
using BloodBusinessLogic.Services;
using BloodDataAccess;
using BloodDataAccess.Repositories;
using RepositoryClasses;

namespace BloodDependencyResolver
{
    public class BloodBusinessLogicModel : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var context = new KSR_BloodEntities();
            
            var unitOfWork = new UnitOfWork(context);
            var examinationsRepository = new ExaminationsRepository(context, unitOfWork);

            builder.RegisterInstance<IUnitOfWork>(unitOfWork);
            builder.RegisterInstance<IExaminationsRepository>(examinationsRepository);

            builder.RegisterInstance<IExaminationsService>(new ExaminationsService(examinationsRepository));

            base.Load(builder);
        }
    }
}
