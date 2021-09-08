using DataLibrary.DataModels.Applicant;
using DataLibrary.DataModels.CreditCard;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.DataModels.ApplicantResponse
{
    public class ApplicantResponse : IApplicantResponse
    {
        [BsonId]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
        public List<ICreditCard> CreditCardOffers { get; set; }
        public DateTime DateOfQuery { get; set; }
        public IApplicant Applicant { get; set; }
        public String Message { get; set; }
    }
}
