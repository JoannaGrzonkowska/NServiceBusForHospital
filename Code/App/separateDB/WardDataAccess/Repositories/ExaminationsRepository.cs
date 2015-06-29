using Messages.Common;
using RepositoryClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardDataAccess.Repositories
{
    public class ExaminationsRepository : RepositoryBase<Examinations, KSR_WardEntities>, IExaminationsRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExaminationsRepository(KSR_WardEntities context,
            IUnitOfWork unitOfWork)
            : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public CommandResult Add(Examinations examination, ref int examinationId)
        {
            Add(examination);
            _unitOfWork.SaveChanges();

            examinationId = examination.Id;

            return new CommandResult();
        }

        public IEnumerable<Examinations> GetExaminationsByPatientDieseaseId(int patientDieseaseId)
        {
            return Context.Set<Examinations>()
                .Where(x => x.PatientDieseaseId == patientDieseaseId)
                .OrderBy(o=>o.WhenExamined);
        }
    }
}
