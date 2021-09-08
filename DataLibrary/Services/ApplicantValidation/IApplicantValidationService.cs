using DataLibrary.DataModels.Applicant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Services.ApplicantValidation
{
    public interface IApplicantValidationService
    {
        IApplicant ValidateApplicant(IApplicant applicant);
    }
}
