using DataLibrary.DataModels.Applicant;
using DataLibrary.DataModels.ApplicantResponse;
using DataLibrary.DataModels.CreditCard;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.MongoSerializers
{
    public class Serializers : ISerializers
    {
        public Serializers()
        {
            RegisterSerializers();
        }

        public void RegisterSerializers()
        {
            BsonSerializer.RegisterSerializer(new ImpliedImplementationInterfaceSerializer<ICreditCard, CreditCard>(BsonSerializer.LookupSerializer<CreditCard>()));
            BsonSerializer.RegisterSerializer(new ImpliedImplementationInterfaceSerializer<IApplicant, Applicant>(BsonSerializer.LookupSerializer<Applicant>()));
            BsonSerializer.RegisterSerializer(new ImpliedImplementationInterfaceSerializer<IApplicantResponse, ApplicantResponse>(BsonSerializer.LookupSerializer<ApplicantResponse>()));
        }
    }
}
