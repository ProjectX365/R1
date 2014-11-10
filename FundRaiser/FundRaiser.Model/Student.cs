using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser.Model
{
    /// <summary>
    /// Class represents datamodel of a student 
    /// </summary>
    public class Student:Entity
    {
        School SchoolInformation { get; set; }

        string StudyYear { get; set; }

    }
}
