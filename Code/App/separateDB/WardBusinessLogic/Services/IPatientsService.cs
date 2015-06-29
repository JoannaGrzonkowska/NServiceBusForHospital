using Messages.Common;
using Messages.Ward;

namespace WardBusinessLogic.Services
{
    public interface IPatientsService
    {
        CommandResult AddIfNotExist(PatientMessage patient, ref int patientId);
    }
}
