
using DBAToolV3.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBATool.Data
{
    public interface IServerDatabase
    {
       Server Get(int id);
       IEnumerable<Server> GetAll();
  
       void Add(Server newServer);
    }
}
