using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundRaiser.Model;

namespace FundRaiser.DAL
{
    public interface IRepository
    {
        bool SignUp(string email, string firstName, string lastName, string UIN, string password);

        bool SignIn(string email, string password, string UIN);

        bool CreateProfile(IEntity entity);
    }
}
