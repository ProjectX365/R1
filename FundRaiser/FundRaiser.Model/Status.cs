using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser.Model
{
    /// <summary>
    /// class represent student status on how they use fund. 
    /// </summary>
    class Status
    {
        /// <summary>
        /// Student Id
        /// </summary>
       public  long StudentId { get; set; }
       
        /// <summary>
        /// Fund Request Id 
        /// </summary>
       public long FundRequestId { get; set; }

        /// <summary>
        /// Additional support document 
        /// </summary>

       public string[] SupportDocumentHref { get; set; }

        /// <summary>
        /// short summary on how they spend money
        /// </summary>
       public string Summary { get; set; }

        /// <summary>
        /// Expense summary 
        /// </summary>
       public IEnumerable<ExpenseDistribution> ExpenseSummary { get; set; }
    }
}
