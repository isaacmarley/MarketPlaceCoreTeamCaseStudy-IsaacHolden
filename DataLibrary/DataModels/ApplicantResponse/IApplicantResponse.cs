using DataLibrary.DataModels.Applicant;
using DataLibrary.DataModels.CreditCard;
using DataLibrary.DataModels.DateModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.DataModels.ApplicantResponse
{
    public interface IApplicantResponse : IDataModel
    {
        IApplicant Applicant { get; set; }
        List<ICreditCard> CreditCardOffers { get; set; }
        DateTime DateOfQuery { get; set; }
        String Message { get; set; }
    }
}
