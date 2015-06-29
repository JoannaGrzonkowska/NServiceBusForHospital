using Messages.Common;
using RepositoryClasses;
using System.Data;
using System.Linq;

namespace WardDataAccess.Repositories
{
    public class PatientsRepository : RepositoryBase<Patients, KSR_WardEntities>, IPatientsRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientsRepository(KSR_WardEntities context,
            IUnitOfWork unitOfWork)
            : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public Patients GetByExtPatientId(int extPatientId)
        {
            return Context.Set<Patients>()
                .Where(x => x.ExtPatientId==extPatientId).FirstOrDefault();
        }

        public CommandResult Add(Patients patient, ref int patientId)
        {
            Add(patient);
            _unitOfWork.SaveChanges();

            patientId = patient.Id;

            return new CommandResult();
        }
    }
}
