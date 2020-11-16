
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Service.Patern;
using Piiii.data.Infrastrucutre;
using Piiii.domain;
using System.Threading.Tasks;
namespace Piiii.service
{
    public class QuizService : Service<quiz>, IQuizService
    {
        static IDatabaseFactory Factory = new DatabaseFactory();

        static IUnitOfWork utk = new UnitOfWork(Factory);



        public QuizService() : base(utk)
        {
        }
    }
}
