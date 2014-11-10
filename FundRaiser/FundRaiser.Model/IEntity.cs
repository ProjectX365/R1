﻿
namespace FundRaiser.Model
{
    /// <summary>
    /// Interface representing entity 
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Entity id 
        /// </summary>
        long Id { get; set; }

        /// <summary>
        /// Entity First Name. 
        /// </summary>
        string FirstName { get; set; }

        /// <summary>
        /// Entity Last Name. 
        /// </summary>
        string LastName { get; set; }

        /// <summary>
        /// Entity email Id. 
        /// </summary>

        string EmailID { get; set; }

        /// <summary>
        /// Entity photo reference. 
        /// </summary>
        string PhotoHref { get; set; }


    }
}