using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Identity.MongoDbCore.Models;
using Microsoft.AspNetCore.Identity;
using MongoDbGenericRepository.Attributes;

namespace MongoIdentityCheck.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the MongodbUser class
    [CollectionName("Users")]
    public class MongodbUser : MongoIdentityUser<Guid>
    {
    }
}
