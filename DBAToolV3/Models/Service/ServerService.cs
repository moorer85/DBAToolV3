using DBAToolV3.Data.Models;
using DBAToolV3.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBAToolV3.Models.Service
{
    public class ServerService : IServer
    {
        private readonly DBAToolV3Context _context = new DBAToolV3Context();

        public void Add(Server server)
        {
            throw new NotImplementedException();
        }

        public void Delete(Server server)
        {
            throw new NotImplementedException();
        }

        public Server Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Server> GetAll()
        {
            return _context.Servers;
        }

        public void Update(Server server)
        {
            throw new NotImplementedException();
        }
    }
}