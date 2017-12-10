using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataAccessDemo.Models
{
    public class RoleModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings=false)]
        public string Name { get; set; }
    }
}