using DataLibrary.DataModels.Applicant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Services.ApplicantValidation
{
    public class ApplicantValidationService : IApplicantValidationService
    {
        public IApplicant ValidateApplicant(IApplicant applicant)
        {
            if (applicant.AnnualIncome == null)
            {
                applicant.AnnualIncome = 0;
            }

            return applicant;
        }
    }
}
