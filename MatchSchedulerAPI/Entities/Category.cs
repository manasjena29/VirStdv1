using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchSchedulerAPI.Entities
{
    [BsonCollection("MatchCategory")]
    public class Category:Document
    {
        public string Name { get; set; }
    }
}
