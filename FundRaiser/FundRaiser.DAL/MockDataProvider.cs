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
        static List<Entity> entityList = new List<Entity>();
        //public static IOrderedEnumerable<Student>
        public bool SignUp(string email, string firstName, string lastName, string UIN, string password)
        {
            entityList.Add(new Entity { EmailID = email, FirstName = firstName, LastName = lastName, Password=password, UIN = UIN, Id = Guid.NewGuid().ToString() });
            return true;
        }

        public bool SignIn(string email, string password, string UIN)
        {
            //TODO:  It's late so will clean this up later
            if (UIN!=null)
            {
                var user = entityList.Find(x=>x.UIN == UIN && x.Password == password);
                return (user != null ? true : false);
            }
            else
            {
                var user = entityList.Find(x => x.EmailID.ToUpper() == email.ToUpper() && x.Password == password);
                return (user != null ? true : false);
            }
        }

        public bool CreateProfile(IEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
