using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessDemo.Code;
using DataAccessDemo.Models;

namespace DataAccessDemo.Controllers
{
    public class UserController : Controller
    {        
        public ActionResult Index()
        {
            var users = from u in Databases.CreateDatabase().GetUsers()
                        select new UserModel() { Id = u.Id, Name = u.Name };

            return View(users);
        }

        public ActionResult Details (int id)
        {
            var user = Databases.CreateDatabase().GetUser(id);

            return View(new UserModel() { Id = user.Id, Name = user.Name });
        }

        public ActionResult Edit (int id)
        {
            var user = Databases.CreateDatabase().GetUser(id);

            return View(new UserModel() { Id = user.Id, Name = user.Name });
        }
    }
}