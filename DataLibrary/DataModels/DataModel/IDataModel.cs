using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.DataModels.DateModel
{
    public interface IDataModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}
