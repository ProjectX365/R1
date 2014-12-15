using System;
namespace FundRaiser.Model
{
    /// <summary>
    /// Entity is base representation of all actors in the system. 
    /// </summary>
    public class Entity : IEntity, IAsset
    {
        /// <summary>
        /// Entity Id 
        /// </summary>
        public string Id { get; set;}

        /// <summary>
        /// Entity /Actor First Name. 
        /// </summary>
        public string FirstName  { get; set;}

        /// <summary>
        /// Entity/ Actor Last Name. 
        /// </summary>
        public string LastName  { get; set;}

        /// <summary>
        /// Entity/ Actor EmailID. 
        /// </summary>
        public string EmailID  { get; set;}
       
        /// <summary>
        /// Entity Photo reference url .
        /// </summary>
        public string PhotoHref { get; set; }
        
        /// <summary>
        /// Entity/ Actor UIN. 
        /// </summary>
        public string UIN  { get; set;}

        /// <summary>
        /// Entity/ Actor Password. 
        /// </summary>
        public string Password { get; set; }

    }
}
