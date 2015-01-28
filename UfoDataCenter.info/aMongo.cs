using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UfoDataCenter.info
{
    public abstract partial class aUfo
    {
        public MongoClient mongoclient = new MongoClient(UfoDB.Connection.settings);

        public MongoCollection<BsonDocument> GetActiveDB()
        {
            var server = this.mongoclient.GetServer();

            var db = server.GetDatabase(this.activeCollection.database);

            return db.GetCollection(this.activeCollection.collection);
        }
    }
}
