using DBATool.Data;
using DBAToolV3.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DBAToolV3.Models.Service
{
    public class DatabaseService : IDatabase
    {

        private readonly DBAToolV3Context _context = new DBAToolV3Context();


        public void Add(ServerDatabase database)
        {
            _context.Databases.Add(database);
            _context.SaveChanges();
        }

        public void Delete(ServerDatabase database)
        {
            _context.Databases.Remove(database);
            _context.SaveChanges();
        }

        public ServerDatabase Get(int id)
        {
            return _context.Databases.FirstOrDefault(v => v.Id == id);
        }

        public IEnumerable<ServerDatabase> GetAll()
        {
            return _context.Databases;
        }

        public void Update(ServerDatabase database)
        {
            _context.Entry(database).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}