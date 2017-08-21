using NamingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NamingService.Services
{
    public class CreateHelper
    {
        NameGeneratorEntities db = new NameGeneratorEntities();

        public int IncreaseNumber(Name model)
        {
            NameGeneratorEntities create = new NameGeneratorEntities();

            var Number2Set = create.Names
                                   .Where(p => p.LocationID == model.LocationID)
                                   .Where(p => p.ProjectID == model.ProjectID)
                                   .Where(p => p.RoleID == model.RoleID)
                                   .Where(p => p.TypeeID == model.TypeeID)
                                   .Where(p => p.PlatformID == model.PlatformID)
                                   .Select(p => p.Number)
                                   .Max();

            if (Number2Set == null)
            {
                return 1;
            }
            else
            {
                return (int)Number2Set + 1;
            }




        }
    }
}