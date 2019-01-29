using DBATool.Data;
using DBAToolV3.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBAToolV3.Models.Service
{
    public class ServerDatabaseService : IServerDatabase
    {

        private readonly DBAToolV3Context _context = new DBAToolV3Context();


        public void Add(Server newServer)
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
    }
}