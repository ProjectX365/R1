using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser.Model
{
    /// <summary>
    /// class represents datamodel of a story.
    /// These stories will be displayed in the home page. i.e student story, school story, Funder story. 
    /// </summary>
    public class Story :IStory
    {
        public EntityTypes EntityType { get; set; }
        public string Description { get; set; }

    }
}
