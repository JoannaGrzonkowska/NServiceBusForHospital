using BusinessLogic.Models.Commands;
using DataAccess;
using DataAccess.Repositories;
using Messages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.CommandHandlers
{
    public class AddExaminationToPatientCommandHandler : IAddExaminationToPatientCommandHandler
    {
        private readonly IExaminationsRepository _examinationsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddExaminationToPatientCommandHandler(
            IExaminationsRepository examinationsRepository,
            IUnitOfWork unitOfWork)
        {
            _examinationsRepository = examinationsRepository;
            _unitOfWork = unitOfWork;
        }

        public CommandResult Add(AddExaminationToPatientCommand command, ref int examinationId)
        {
            var examination = new Examinations
            {
                PatientDieseaseId = command.PatientDieseaseId,
                ExaminationType = (int) command.ExaminationType,
                LogType = (int)command.LogType,
                Comment = command.Comment
            };
            _examinationsRepository.Add(examination);
            _unitOfWork.SaveChanges();

            examinationId = examination.Id;

            return new CommandResult();
        }
    }
}
