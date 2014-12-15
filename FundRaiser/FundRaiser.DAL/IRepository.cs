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
        bool SignUp(string userName, string password);

        bool SignIn(string userName, string password, AuthenticationSourceEnum  authenticationSource);

        bool CreateProfile(IEntity entity);


    }
}
