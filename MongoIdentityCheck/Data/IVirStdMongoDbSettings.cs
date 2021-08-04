using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoIdentityCheck.Data
{
    public interface IVirStdMongoDbSettings
    {
        public string CategoryCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
