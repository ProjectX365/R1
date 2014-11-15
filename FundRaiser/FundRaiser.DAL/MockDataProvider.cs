using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundRaiser.Model;

namespace FundRaiser.DAL
{
    public  class MockDataProvider :IRepository
    {
        //public static IOrderedEnumerable<Student>
        public bool SignUp(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public bool SignIn(string userName, string password, AuthenticationSourceEnum authenticationSource)
        {
            throw new NotImplementedException();
        }

        public bool CreateProfile(IEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
