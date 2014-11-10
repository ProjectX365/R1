namespace FundRaiser.Model
{
    /// <summary>
    /// Class representing fund 
    /// </summary>
    class Fund
    {
        /// <summary>
        /// Fund ID. 
        /// </summary>
        public long FundId { get; set; }

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
