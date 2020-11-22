using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer
{
    public interface IConnection
    {
        bool CreateConnection(string conString);
        bool TestConnection();
        bool ExecuteNoRespQuery(string query);
        object ExecuteQuery(string query);
        bool ExecuteScript(string query);
    }
}
