
namespace FundRaiser.Model
{
    /// <summary>
    /// enumerator representing current fund status. 
    /// </summary>
    public enum FundStatusEnum
    {
        ACTIVE, //has been allocated/locked
        REFUND, //Fund has been returned back to their account 
        DISTRIBUTED, //Fund has been used

    }
}
