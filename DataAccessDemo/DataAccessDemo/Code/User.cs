using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessDemo.Code
{
    public class User
    {
        #region Construction

        public User ()
        {
        } 

        public User ( int id )
        {
            Id = id;
        }
        #endregion

        public int Id { get;  private set; }

        public string Name { get; set; }
    }
}