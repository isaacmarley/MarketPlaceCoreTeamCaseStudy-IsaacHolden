using DataLibrary.DataModels.Applicant;
using DataLibrary.DataModels.ApplicantResponse;
using DataLibrary.DataModels.CreditCard;
using DataLibrary.Services.ApplicantResponses;
using DataLibrary.Services.ApplicantValidation;
using DataLibrary.Services.CreditCardResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPlaceCoreTeamCaseStudy_IsaacHolden.Controllers
{
    [ApiController]
    public class CreditCardResponseController : ControllerBase
    {
        private IApplicantResponsesService _ApplicantResponsesService { get; }
        private IApplicantValidationService _ApplicantValidationService { get; }
        private ICreditCardResponseService _CreditCardResponseService { get; }

        public CreditCardResponseController(ICreditCardResponseService creditCardResponseService, IApplicantResponsesService applicantResponsesService, IApplicantValidationService applicantValidation)
        {
            _CreditCardResponseService = creditCardResponseService;
            _ApplicantResponsesService = applicantResponsesService;
            _ApplicantValidationService = applicantValidation;
        }

        [HttpPost("api/creditcardresponse")]
        public async Task<IApplicantResponse> Get(Applicant applicant)
        {
            // TODO: return type of ValidateApplicant method returns IApplicant.
            // IApplicant Interface type not used in method signature, as System.Text.Json.Serialization library throws exception as it cannot serialize an interface.
            // Perhaps using Newtonsoft JSON deserialization might be possible. Or maybe a custom deserializer.
            applicant = (Applicant)_ApplicantValidationService.ValidateApplicant(applicant);

            IApplicantResponse applicantResponse = new ApplicantResponse()
            {
                Applicant = applicant,
                DateOfQuery = DateTime.UtcNow
            };

            applicantResponse = await _CreditCardResponseService.ReturnResponse(applicantResponse);

            await _ApplicantResponsesService.Insert(applicantResponse);

            return applicantResponse;
        }

        [HttpGet("api/applicantresponses")]
        public async Task<List<IApplicantResponse>> Get()
        {
            return await _ApplicantResponsesService.GetAll();
        }
    }
}
