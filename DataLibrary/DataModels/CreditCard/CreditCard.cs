using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.DataModels.CreditCard
{
    public class CreditCard : ICreditCard
    {
        [BsonId]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
        public String NameOfCard { get; set; }
        public Single APR { get; set; }
        public String PromotionalMessage { get; set; }
    }
}
