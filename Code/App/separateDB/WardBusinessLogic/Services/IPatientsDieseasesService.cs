using Messages;
using Messages.Common;
using RepositoryClasses.Models;
using System.Collections.Generic;

namespace WardBusinessLogic.Services
{
    public interface IPatientsDieseasesService
    {
        CommandResult Add(PatientDieseaseMessage patientDiesease, int patientId, ref int patientDieseaseId);
        PatientsDieseasesModel GetByExtPatientDieseaseId(int patientDieseaseId);
    }
}
