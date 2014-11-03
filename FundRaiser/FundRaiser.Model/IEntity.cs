using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser.Model
{
    public interface IEntity
    {
        long Id { get; set; }
        string name { get; set; }
    }
}
