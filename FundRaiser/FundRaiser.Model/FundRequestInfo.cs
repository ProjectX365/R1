using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser.Model
{
    /// <summary>
    ///  class represent all the information that needs to be submitted during Fund request. 
    /// </summary>
    public class FundRequestInfo
    {
        /// <summary>
        /// Fund request Info Id. 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Student Id. 
        /// </summary>
        public long StudentId { get; set; }

        /// <summary>
        /// Image reference, 
        /// NOTE: This image is different than profile image href. Student can add diffrent image during fund request. 
        /// </summary>
        public string ImageHref{get;set;}

        /// <summary>
        /// Title given for fund request. 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// short description about fund request 
        /// </summary>
        public string Blurb { get; set; }

        /// <summary>
        /// UTC Date time for expiration.. needs to converted to local on client. 
        /// </summary>
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// Requested fund amount. 
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// List of Expense categories. 
        /// </summary>
        public IEnumerable<ExpenseCategoryEnum> ExpenseCategories { get; set; }

        /// <summary>
        /// Fund Requested semister. 
        /// </summary>
        public SemisterEnum Semister { get; set; }

        public bool IsApprove { get; set; }

    }
}
