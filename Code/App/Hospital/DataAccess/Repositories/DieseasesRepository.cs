
namespace DataAccess.Repositories
{
    public class DieseasesRepository: RepositoryBase<Dieseases, HospitalKSREntities>, IDieseasesRepository
    {
        public DieseasesRepository(HospitalKSREntities context)
            : base(context)
        {

        }
    }
}
