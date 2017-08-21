using NamingService.Models;
using NamingService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NamingService.Controllers
{
    public class NameController : ApiController
    {


        CreateHelper SerialNumber = new CreateHelper();
        //public List<Name> Get()
        //{
        //    return NameModel.GetAllUsers();
        //}
        public string Get(Name name)
        {
            return NameModel.GetUser(name);
        }
        public string Post([FromBody]CreateModel model)
        {
            NameGeneratorEntities db = new NameGeneratorEntities();
            #region UnusedBlock
            //model.Locations = new SelectList(db.Locations, "ID", "LocationName", model.LocationID);
            //model.Platforms = new SelectList(db.Platformms, "ID", "PlatfromName", model.PlatformID);
            //model.Projects = new SelectList(db.Projects, "ID", "ProjectName", model.ProjectID);
            //model.Roles = new SelectList(db.Rolees, "ID", "RoleName", model.RoleID);
            //model.Types = new SelectList(db.Typees, "ID", "TypeName", model.TypeeID);
            #endregion

            //Create Model -> Entity2Save
            Name entity = new Name();
            entity.ProjectID = model.ProjectID;
            entity.LocationID = model.LocationID;
            entity.RoleID = model.RoleID;
            entity.PlatformID = model.PlatformID;
            entity.TypeeID = model.TypeeID;
            entity.Comment = model.Comment;
            #region UnusedBlock
            //entity.Location = db.Locations.AsNoTracking().First(l => l.ID == model.LocationID);
            //entity.Rolee = db.Rolees.AsNoTracking().First(r => r.ID == model.RoleID);
            //entity.Project = db.Projects.AsNoTracking().First(r => r.ID == model.ProjectID);
            //entity.Platformm = db.Platformms.AsNoTracking().First(r => r.ID == model.PlatformID);
            //entity.Typee = db.Typees.AsNoTracking().First(r => r.ID == model.TypeeID);

            //entity.Project.ProjectSName = (entity.Project.ProjectSName + "0000").Substring(0, 4);
            //entity.Rolee.RoleSName = (entity.Rolee.RoleSName + "000").Substring(0, 3);
            #endregion

            //Entity2Save Set Location-Role-Project-Platform-Type
            Location LocationName = db.Locations.Where(l => l.ID == model.LocationID).SingleOrDefault();
            entity.Location = LocationName;
            Rolee RoleName = db.Rolees.Where(l => l.ID == model.RoleID).SingleOrDefault();
            entity.Rolee = RoleName;
            Project ProjectName = db.Projects.Where(l => l.ID == model.ProjectID).SingleOrDefault();
            entity.Project = ProjectName;
            Platformm PlatformName = db.Platformms.Where(l => l.ID == model.PlatformID).SingleOrDefault();
            entity.Platformm = PlatformName;
            Typee typeName = db.Typees.Where(t => t.ID == model.TypeeID).SingleOrDefault();
            entity.Typee = typeName;

            //Set The Correct Number and DateTime for Entity2Save
            entity.Number = SerialNumber.IncreaseNumber(entity);
            entity.CreateDate = DateTime.Now;

            //Set The HostName
            string GNAME = LocationName.LocationSName + "-" + typeName.TypeSName + (RoleName.RoleSName + "000").Substring(0, 3) + "-" + PlatformName.PlatformSName + (ProjectName.ProjectSName + "0000").Substring(0, 4) + entity.Number.Value.ToString("00");
            entity.GeneratedName = GNAME;

            //Insert Database
            db.Names.Add(entity);
            db.SaveChanges();
            db.Dispose();

            //Post The New Generated Name
            return NameModel.GetUser(entity);

        }
    }
}