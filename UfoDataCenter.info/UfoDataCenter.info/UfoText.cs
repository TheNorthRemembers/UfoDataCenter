using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using MongoDB;
using MongoDB.Driver;
using MongoDB.Shared;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using MongoDB.Bson.Serialization;
using UfoDB;


namespace UfoDataCenter.info
{
    public partial class UfoText : aUfo
    {


        public override UfoCollection ufo_reports
        {
            get
            {
                return new UfoCollection
                {
                    database = "ufodatacenter",
                    collection = "ufo_reports"
                };
            }
        }



        public override UfoTextDoc GetRandom(UfoCollection settings)
        {
            var mongoclient = new MongoClient(UfoDB.Connection.settings);

            var server = mongoclient.GetServer();

            var db = server.GetDatabase(settings.database);

            var collect = db.GetCollection(settings.collection);

            Random rnd = new Random();

            int count = this.GetCount(settings);

            int skip = rnd.Next(0, (count - 1));         

            var document = BsonSerializer.Deserialize<UfoTextDoc>(collect.AsQueryable().Skip(skip).First());

            return document;
        }


        public override int GetCount(UfoCollection settings)
        {
            var mongoclient = new MongoClient(UfoDB.Connection.settings);

            var server = mongoclient.GetServer();

            var db = server.GetDatabase(settings.database);

            var collect = db.GetCollection(settings.collection);

            var count = collect.FindAll().Count();

            return (int)count;
        }

    }
}
