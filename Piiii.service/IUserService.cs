using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using Piiii.domain;
using Service.Patern;

namespace Piiii.service
{
    interface IUserService : IService<user>
    {
        user FindRoleByName(string name);
    }
}
