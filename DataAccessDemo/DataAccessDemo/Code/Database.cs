using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using P3Net.Kraken.Data;
using P3Net.Kraken.Data.Common;

namespace DataAccessDemo.Code
{
    public static class Database
    {
        public static IEnumerable<Role> GetRoles ( this ConnectionManager source )
        {
            var cmd = new AdhocQuery("SELECT Id, Name FROM Roles");

            return source.ExecuteQueryWithResults(cmd, r =>
                new Role(r.GetInt32OrDefault("Id")) { Name = r.GetStringOrDefault("Name") }
                );
        }

        public static Role GetRole ( this ConnectionManager source, int id )
        {
            var cmd = new AdhocQuery("SELECT Id, Name FROM Roles where Id = @id").WithParameters(
                                        InputParameter.Named("id").WithValue(id)
                                    );
            
            return source.ExecuteQueryWithResult(cmd, 
                        r => new Role(r.GetInt32OrDefault("Id")) { Name = r.GetStringOrDefault("Name") }); 
        }

        public static IEnumerable<User> GetUsers ( this ConnectionManager source )
        {
            var users = new List<User>();

            var cmd = new AdhocQuery("SELECT Id, Name FROM Users");

            var ds = new DataSet();
            source.FillDataSet(cmd, ds);

            if (ds.TableCount() > 0)
            {
                foreach (var row in ds.Tables[0].AsEnumerable())                        
                {
                    users.Add(new User(row.GetInt32ValueOrDefault("Id")) { Name = row.GetStringValueOrDefault("Name") });                            
                };
            };

            return users;
        }

        public static User GetUser (this ConnectionManager source, int id)
        {
            var cmd = new AdhocQuery("SELECT Id, Name FROM Users where Id = @id").WithParameters(
                                        InputParameter.Named("id").WithValue(id)
                                    );

            return source.ExecuteQueryWithResult(cmd, 
                                r => new User(r.GetInt32OrDefault("Id")) { Name = r.GetStringOrDefault("Name") });
        }
    }
}