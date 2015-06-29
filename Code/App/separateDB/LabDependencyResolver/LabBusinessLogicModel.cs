using Autofac;
using LabBusinessLogic.Services;
using LabDataAccess;
using LabDataAccess.Repositories;
using RepositoryClasses;

namespace LabDependencyResolver
{
    public class LabBusinessLogicModel : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var context = new KSR_LabEntities();
            
            var unitOfWork = new UnitOfWork(context);
            var examinationsRepository = new ExaminationsRepository(context, unitOfWork);

            builder.RegisterInstance<IUnitOfWork>(unitOfWork);
            builder.RegisterInstance<IExaminationsRepository>(examinationsRepository);

            builder.RegisterInstance<IExaminationsService>(new ExaminationsService(examinationsRepository));

            base.Load(builder);
        }
    }
}
