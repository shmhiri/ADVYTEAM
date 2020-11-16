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
    public class ExpancesService : Service<missionexpenses>, IExpancesService
    {
        static IDatabaseFactory Factory = new DatabaseFactory();

        static IUnitOfWork utk = new UnitOfWork(Factory);

        public ExpancesService() : base(utk)
        {
        }

        public IEnumerable<missionexpenses> GetexpanssessByMission(int IdMission)
        {
            return GetMany(p => p.mission.refrence == IdMission);
        }
        public IEnumerable<missionexpenses> GetexpanssessByuser(int iduser)
        {
            return GetMany(p => p.user.userId == iduser);
        }
    }
}
