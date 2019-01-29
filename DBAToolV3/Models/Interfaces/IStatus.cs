
using DBAToolV3.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBATool.Data
{
    public interface IDatabaseStatus
    {

        DatabaseStatus Get(int id);
        void Add(DatabaseStatus newStatus);

        IEnumerable<DatabaseStatus> GetAll();

    }
}
