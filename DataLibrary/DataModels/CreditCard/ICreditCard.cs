using DataLibrary.DataModels.DateModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.DataModels.CreditCard
{
    public interface ICreditCard : IDataModel
    {
        public String NameOfCard { get; set; }
        public Single APR { get; set; }
        public String PromotionalMessage { get; set; }
    }
}
