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
        public string defaultCollection = "uforeports";
        public MongoCollection<BsonDocument> GetActiveDB()
        {
            var server = this.mongoclient.GetServer();
            try
            {
                var db = server.GetDatabase(this.activeCollection.database);

                return db.GetCollection(this.activeCollection.collection);
            }
            catch(Exception e)
            {
                //if the db or collection does not exist
                this.SetActive(defaultCollection);

                var db = server.GetDatabase(this.activeCollection.database);

                return db.GetCollection(this.activeCollection.collection);
            }
        }
    }
}
