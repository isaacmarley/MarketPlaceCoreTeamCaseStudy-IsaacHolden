using DataLibrary.DataModels.Applicant;
using DataLibrary.DataModels.ApplicantResponse;
using DataLibrary.DataModels.CreditCard;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary.Services.ApplicantResponses
{
    public interface IApplicantResponsesService
    {
        Task<List<IApplicantResponse>> GetAll();
        Task Insert(IApplicantResponse applicantResponse);
    }
}