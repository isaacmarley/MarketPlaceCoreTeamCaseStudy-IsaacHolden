using DataLibrary.DataModels.DateModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.DataModels.Applicant
{
    public interface IApplicant : IDataModel
    {
        String FirstName { get; set; }
        String LastName { get; set; }
        DateTime DateOfBirth { get; set; }
        Int32 AnnualIncome { get; set; }
    }
}
