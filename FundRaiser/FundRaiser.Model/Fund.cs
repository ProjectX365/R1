namespace FundRaiser.Model
{
    /// <summary>
    /// Class representing fund 
    /// </summary>
    public class Fund
    {
        /// <summary>
        /// Fund ID.- internal unique id 
        /// </summary>
        public long FundId { get; set; }

        //Id - where the money is from
        public long FunderId { get; set; }

        //RequestId - where the money is going to 
        public long FundRequestId { get; set; }

        /// <summary>
        /// Fund Amount. 
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Current Fund Status. 
        /// </summary>
        public FundStatusEnum Status { get; set; }
    }
}
