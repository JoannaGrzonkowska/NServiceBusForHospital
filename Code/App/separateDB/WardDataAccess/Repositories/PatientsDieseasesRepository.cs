using Messages;
using Messages.Common;
using RepositoryClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardDataAccess.Repositories
{
    public class PatientsDieseasesRepository : RepositoryBase<PatientsDieseases, KSR_WardEntities>, IPatientsDieseasesRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientsDieseasesRepository(KSR_WardEntities context,
            IUnitOfWork unitOfWork)
            : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public CommandResult Add(PatientsDieseases patientDiesease, ref int patientDieseaseId)
        {
            Add(patientDiesease);
            _unitOfWork.SaveChanges();

            patientDieseaseId = patientDiesease.Id;

            return new CommandResult();
        }

        public PatientsDieseases GetByExtPatientDieseaseId(int extPatientDieseaseId)
        {
            return Context.Set<PatientsDieseases>()
                .FirstOrDefault(x => x.ExtPatientDieseaseId == extPatientDieseaseId);
        }
     }
}
