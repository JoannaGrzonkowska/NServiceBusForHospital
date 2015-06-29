
using Messages.Common;
using RepositoryClasses;
namespace WardDataAccess.Repositories
{
    public interface IPatientsDieseasesRepository : IRepository<PatientsDieseases>
    {
        CommandResult Add(PatientsDieseases patientDiesease, ref int patientDieseaseId);
        PatientsDieseases GetByExtPatientDieseaseId(int extPatientDieseaseId);
    }
}
