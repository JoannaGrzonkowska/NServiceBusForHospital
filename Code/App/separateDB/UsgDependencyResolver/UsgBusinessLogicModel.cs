using Autofac;
using RepositoryClasses;
using UsgBusinessLogic.Services;
using UsgDataAccess;
using UsgDataAccess.Repositories;

namespace UsgDependencyResolver
{
    public class UsgBusinessLogicModel : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var context = new KSR_UsgEntities();
            
            var unitOfWork = new UnitOfWork(context);
            var examinationsRepository = new ExaminationsRepository(context, unitOfWork);

            builder.RegisterInstance<IUnitOfWork>(unitOfWork);
            builder.RegisterInstance<IExaminationsRepository>(examinationsRepository);

            builder.RegisterInstance<IExaminationsService>(new ExaminationsService(examinationsRepository));

            base.Load(builder);
        }
    }
}
