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
using UfoDB;


namespace UfoDataCenter.info
{
    public partial class UfoText : aUfoText
    {
        
        public override string GetTextRandom(UfoCollection settings)
        {
            
            var mongoclient = new MongoClient(UfoDB.Connection.settings);
            var server = mongoclient.GetServer();
            var db = server.GetDatabase(settings.database);

            var collect = db.GetCollection(settings.collection);

            var document = collect.FindAll().Count().ToString();

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
