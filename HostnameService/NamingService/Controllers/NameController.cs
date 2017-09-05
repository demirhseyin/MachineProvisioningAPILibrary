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

        public string Get(Name name)
        {
            return NameModel.GetUser(name);
        }
        public string Post([FromBody]CreateModel model)
        {
            NameGeneratorEntities db = new NameGeneratorEntities();


            //Create Model -> Entity2Save
            Name entity = new Name();
            entity.ProjectID = model.ProjectID;
            entity.LocationID = model.LocationID;
            entity.RoleID = model.RoleID;
            entity.PlatformID = model.PlatformID;
            entity.TypeeID = model.TypeeID; 
            entity.Comment = model.Comment;


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

            //DENEME

            //DENDEME2

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