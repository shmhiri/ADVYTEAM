
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Service.Patern;
using Piiii.data.Infrastrucutre;
using Piiii.domain;


namespace Piiii.service
{
    public class EvaluationService : Service<selfevaluation>, IEvaluationService
    {
        static IDatabaseFactory Factory = new DatabaseFactory();

        static IUnitOfWork utk = new UnitOfWork(Factory);

        public EvaluationService() : base(utk)
        {
        }

    }
}