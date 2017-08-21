using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NamingService.Models
{
    public class CreateModel
    {
        [StringLength(50)]
        public string GeneratedName { get; set; }

        [StringLength(10)]
        public string SName { get; set; }
        public int? LocationID { get; set; }

        public int? RoleID { get; set; }

        public int? TypeeID { get; set; }

        public int? PlatformID { get; set; }

        public int? ProjectID { get; set; }

        public string Comment { get; set; }

        [Range(1, 99)]

        public int? Number { get; set; }

        public SelectList Locations { get; set; }

        public SelectList Platformms { get; set; }

        public SelectList Projects { get; set; }

        public SelectList Roles { get; set; }

        public SelectList Types { get; set; }
        public SelectList Platforms { get; internal set; }
    }
}