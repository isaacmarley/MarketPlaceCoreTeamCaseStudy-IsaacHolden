using DataLibrary.DataModels.Applicant;
using DataLibrary.DataModels.ApplicantResponse;
using DataLibrary.DataModels.CreditCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Services.CreditCardResponse
{
    public interface ICreditCardResponseService
    {
        Task<IApplicantResponse> ReturnResponse(IApplicantResponse applicantResponse);
    }
}
