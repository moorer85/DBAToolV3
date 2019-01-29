using DBAToolV3.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBATool.Data
{
    public interface IDatabase
    {
        ServerDatabase Get(int id);
        void Add(ServerDatabase database);
        void Update(ServerDatabase database);
        void Delete(ServerDatabase database);
  
        IEnumerable<ServerDatabase> GetAll();
    }
}
