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
    public class EmployeeService : Service<employee>, IEmployeeService
    {
        static IDatabaseFactory Factory = new DatabaseFactory();

        static IUnitOfWork utk = new UnitOfWork(Factory);

        public EmployeeService() : base(utk)
        {
        }
    }
}
