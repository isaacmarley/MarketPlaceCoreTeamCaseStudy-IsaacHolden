using DataLibrary.DataModels.CreditCard;
using System.Threading.Tasks;

namespace DataLibrary.Services.CreditCard
{
    public interface ICreditCardService
    {
        Task<ICreditCard> GetCard(string name);
    }
}