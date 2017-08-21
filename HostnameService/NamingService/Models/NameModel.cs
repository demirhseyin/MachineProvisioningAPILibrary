using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace NamingService.Models
{
    public class NameModel
    {
        //public static List<Name> GetAllUsers()
        //{
        //    NameGeneratorEntities dataContext = new NameGeneratorEntities();
        //    var query = from Name
        //                in dataContext.Names
        //                select Name;
        //    return query.ToList();
        //}

        public static string GetUser(Name model)
        {
            NameGeneratorEntities dataContext = new NameGeneratorEntities();
            //var newHost = dataContext.Names.Find(HOST);


            //var query = (from Name in dataContext.Names

            //             where Name==HOST
            //             select Name.ID).Max();




            var Number2Set = dataContext.Names
                                       .Where(p => p.LocationID == model.LocationID)
                                       .Where(p => p.ProjectID == model.ProjectID)
                                       .Where(p => p.RoleID == model.RoleID)
                                       .Where(p => p.TypeeID == model.TypeeID)
                                       .Where(p => p.PlatformID == model.PlatformID)
                                       .Select(p => p.ID)
                                       .Max();
            Name myHost = dataContext.Names.Where(h => h.ID == Number2Set).FirstOrDefault();
            return myHost.GeneratedName;
        }

        [HttpPost]
        public static void InsertUser(Name newName)
        {
            NameGeneratorEntities dataContext = new NameGeneratorEntities();
            dataContext.Names.Add(newName);
            dataContext.SaveChanges();
            //return newName.GeneratedName.ToString();
        }
    }
}
    
