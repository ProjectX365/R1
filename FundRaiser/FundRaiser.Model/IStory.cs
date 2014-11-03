using System;
namespace FundRaiser.Model
{
    interface IStory
    {
        string Description { get; set; }
        EntityTypes EntityType { get; set; }
    }
}
