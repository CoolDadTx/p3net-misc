using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessDemo.Code;
using DataAccessDemo.Models;

namespace DataAccessDemo.Controllers
{
    public class RoleController : Controller
    {     
        public ActionResult Index()
        {
            var roles = from r in Databases.CreateDatabase().GetRoles()
                        select new RoleModel() { Id = r.Id, Name = r.Name };

            return View(roles);
        }

        public ActionResult Details ( int id )
        {
            var role = Databases.CreateDatabase().GetRole(id);

            return View(new RoleModel() { Id = role.Id, Name = role.Name });
        }

        public ActionResult Edit (int id)
        {
            var role = Databases.CreateDatabase().GetRole(id);

            return View(new RoleModel() { Id = role.Id, Name = role.Name });
        }
    }
}