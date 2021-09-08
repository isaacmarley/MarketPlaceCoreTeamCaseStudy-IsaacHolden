using DataLibrary.DataModels.Applicant;
using DataLibrary.DataModels.ApplicantResponse;
using DataLibrary.DataModels.CreditCard;
using DataLibrary.Services.Mongo;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Services.ApplicantResponses
{
    public class ApplicantResponsesService : IApplicantResponsesService
    {
        private readonly IMongoContext _MongoContext;

        public ApplicantResponsesService(IMongoContext mongoContext)
        {
            _MongoContext = mongoContext;
        }

        public async Task Insert(IApplicantResponse applicantResponse)
        {
            await _MongoContext.GetCollection<IApplicantResponse>().InsertOneAsync(applicantResponse);
        }

        public async Task<List<IApplicantResponse>> GetAll()
        {
            FilterDefinition<IApplicantResponse> filterDefinition = Builders<IApplicantResponse>.Filter.Empty;
            FindOptions<IApplicantResponse> findOptions = new FindOptions<IApplicantResponse>();

            IAsyncCursor<IApplicantResponse> cursor = await _MongoContext.GetCollection<IApplicantResponse>().FindAsync(filterDefinition, findOptions);

            return await cursor.ToListAsync();
        }
    }
}
