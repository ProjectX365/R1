namespace FundRaiser.Model
{
    /// <summary>
    /// class representation of fund expense distribution. 
    /// </summary>
    public class ExpenseDistribution
    {
        /// <summary>
        /// Fund category, tells about where fund is spend. 
        /// </summary>
        public ExpenseCategoryEnum Category { get; set; }

        /// <summary>
        /// Fund amount. 
        /// </summary>
        public double Amount{ get; set; }
    }
}
