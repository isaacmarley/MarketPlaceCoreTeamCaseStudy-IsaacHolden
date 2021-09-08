using DataLibrary.DataModels.Applicant;
using DataLibrary.DataModels.ApplicantResponse;
using DataLibrary.DataModels.CreditCard;
using DataLibrary.Services.CreditCard;
using DataLibrary.Services.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Services.CreditCardResponse
{
    public class CreditCardResponseService : ICreditCardResponseService
    {
        public ICreditCardService _CreditCardService { get; }

        public CreditCardResponseService(ICreditCardService creditCardService)
        {
            _CreditCardService = creditCardService;
        }

        public async Task<IApplicantResponse> ReturnResponse(IApplicantResponse applicantResponse)
        {
            List<ICreditCard> creditCards = new List<ICreditCard>();

            // Applicant is over the age of 18?
            if (applicantResponse.Applicant.DateOfBirth.AddYears(18) < DateTime.Now)
            {

                if (applicantResponse.Applicant.AnnualIncome > 30000)
                {
                    creditCards.Add(await _CreditCardService.GetCard("BarclayCard"));
                }
                else
                {
                    creditCards.Add(await _CreditCardService.GetCard("Vanquis"));
                }

                applicantResponse.Message = "Congratulations! There are credit cards available for you!";

            }
            else
            {
                applicantResponse.Message = "no credit cards are available.";
            }

            applicantResponse.CreditCardOffers = creditCards;

            return applicantResponse;
        }
    }
}