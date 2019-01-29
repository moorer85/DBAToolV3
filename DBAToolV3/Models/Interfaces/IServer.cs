using DBAToolV3.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAToolV3.Models.Interfaces
{
    public interface IServer
    {

        Server Get(int id);
        void Add(Server server);
        void Update(Server server);
        void Delete(Server server);

        IEnumerable<Server> GetAll();


    }
}
