using System;
namespace FundRaiser.Model
{
    /// <summary>
    /// interface representing story, sotry is short note from active users 
    /// </summary>
    public interface IStory
    {
        /// <summary>
        /// short description 
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Entity type
        /// </summary>
        EntityTypes EntityType { get; set; }
    }
}
