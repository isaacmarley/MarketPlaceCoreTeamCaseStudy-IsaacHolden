using DataLibrary.DataModels.CreditCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using DataLibrary.Services.Mongo;

namespace DataLibrary.Services.CreditCard
{
    public class CreditCardService : ICreditCardService
    {
        private readonly IMongoContext _MongoContext;

        public CreditCardService(IMongoContext mongoContext)
        {
            _MongoContext = mongoContext;

            CreateCreditCards();
        }

        public void CreateCreditCards()
        {
            FilterDefinition<ICreditCard> filterDefinition = Builders<ICreditCard>.Filter.Empty;
            FindOptions findOptions = new FindOptions();

            IFindFluent<ICreditCard, ICreditCard> cursor = _MongoContext.GetCollection<ICreditCard>().Find(filterDefinition, findOptions);

            if (cursor.CountDocuments() == 0)
            {
                ICreditCard barclaysCreditCard = new DataModels.CreditCard.CreditCard()
                {
                    NameOfCard = "BarclayCard",
                    APR = 3.9f,
                    PromotionalMessage = "Dummy promotional message!"
                };

                ICreditCard vanquisCreditCard = new DataModels.CreditCard.CreditCard()
                {
                    NameOfCard = "Vanquis",
                    APR = 3.7f,
                    PromotionalMessage = "Congratulations!"
                };

                _MongoContext.GetCollection<ICreditCard>().InsertOne(barclaysCreditCard);
                _MongoContext.GetCollection<ICreditCard>().InsertOne(vanquisCreditCard);

            }
        }

        public async Task<ICreditCard> GetCard(String name)
        {
            FilterDefinition<ICreditCard> filterDefinition = Builders<ICreditCard>.Filter.Where(a => a.NameOfCard.Equals(name));
            FindOptions<ICreditCard> findOptions = new FindOptions<ICreditCard>();

            IAsyncCursor<ICreditCard> cursor = await _MongoContext.GetCollection<ICreditCard>().FindAsync(filterDefinition, findOptions);

            return await cursor.FirstOrDefaultAsync();
        }
    }
}
