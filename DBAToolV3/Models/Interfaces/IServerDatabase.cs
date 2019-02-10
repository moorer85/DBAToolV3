
using DBAToolV3.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBATool.Data
{
    public interface IServerDatabase
    {
       ServerDatabase Get(int id);
       IEnumerable<ServerDatabase> GetAll();

        IEnumerable<ServerDatabase> GetAll(int serverid);


        void Add(ServerDatabase serverdatabase);
    }
}
