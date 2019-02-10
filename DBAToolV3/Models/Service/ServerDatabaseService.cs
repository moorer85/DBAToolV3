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


        public void Add(ServerDatabase newServerDatabase)
        {
            _context.ServerDatabases.Add(newServerDatabase);
            _context.SaveChanges();
        }

        public ServerDatabase Get(int id)
        {
            return _context.ServerDatabases.Find(id);
        }


        public IEnumerable<ServerDatabase> GetAll()
        {
            return _context.ServerDatabases.ToList();
        }

        IEnumerable<ServerDatabase> IServerDatabase.GetAll(int serverid)
        {
            return _context.ServerDatabases.Where(d => d.ServerId == serverid);
        }
    }
}