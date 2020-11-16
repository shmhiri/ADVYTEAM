
using Service.Patern;
using Piiii.data.Infrastrucutre;
using Piiii.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piiii.service
{
    public class UserService : Service<user>, IUserService
    {
        static IDatabaseFactory Factory = new DatabaseFactory();

        static IUnitOfWork utk = new UnitOfWork(Factory);

        public UserService() : base(utk)
        {
        }

        public user FindRoleByName(string name)
        {
            IEnumerable<user> ls = this.GetMany().Where(p => p.email == name).Take(1);
            user c = new user();
            foreach (var i in ls)
            {
                c.nom = i.nom;
                c.password = i.password;
                c.role = i.role;
            }
            return c;
        }
    }
}
