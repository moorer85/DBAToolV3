using DBAToolV3.Data.Models;
using DBAToolV3.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DBAToolV3.Models.Service
{
    public class ServerService : IServer
    {
        private readonly DBAToolV3Context _context = new DBAToolV3Context();

        public void Add(Server server)
        {
            _context.Servers.Add(server);
            _context.SaveChanges();
        }

        public void Delete(Server server)
        {
            _context.Servers.Remove(server);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Server Get(int? id)
        {
            return _context.Servers.FirstOrDefault(v => v.Id == id);
        }

        public IEnumerable<Server> GetAll()
        {
            return _context.Servers;
        }

        public void Update(Server server)
        {
            _context.Entry(server).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}