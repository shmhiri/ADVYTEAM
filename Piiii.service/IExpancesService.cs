using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Piiii.domain;
using Service.Patern;

namespace Piiii.service
{
    interface IExpancesService : IService<missionexpenses>
    {
        IEnumerable<missionexpenses> GetexpanssessByMission(int IdCategory);
        IEnumerable<missionexpenses> GetexpanssessByuser(int iduser);


    }
}
