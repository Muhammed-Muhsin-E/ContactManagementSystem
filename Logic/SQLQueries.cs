using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManagementSystem.Logic
{
    internal static class SQLQueries
    {
        internal readonly static string SelectQuery = "SELECT * FROM Contact";
        internal readonly static string InsertQuery =
            "INSERT INTO Contact (Name, EmailId, PhoneNumber, Address) VALUES ('{0}', '{1}', '{2}', '{3}')";
        internal readonly static string UpdateQuery =
            "UPDATE Contact SET Name = '{1}', EmailId = '{2}', PhoneNumber = '{3}', Address = '{4}' WHERE Id = '{0}'";
        internal readonly static string DeleteQuery =
            "DELETE FROM Contact WHERE Id = '{0}'";
    }
}