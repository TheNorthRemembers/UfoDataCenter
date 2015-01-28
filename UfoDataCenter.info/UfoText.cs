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

        //Enumnerator for future; hopefully we have multiple sources later and can use Enumerator to access 
        //No metter what will keep SQL table with collection info        
        public UfoText(string c_name) : base(c_name) { }
        public override IEnumerable<UfoCollection> reports
        {
            get {
                List<UfoCollection> r = new List<UfoCollection>();
                r.Add(this.ufo_reports);
                return r;            
            }
        }

        public override UfoDoc GetSingle(int Nth)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<UfoDoc> GetPage(int page, int perpage)
        {
            throw new NotImplementedException();
        }

        public override UfoDoc GetSingle(BsonObjectId id)
        {
            throw new NotImplementedException();
        }
        private UfoCollection ufo_reports
        {
            get
            {
                return new UfoCollection
                {
                    database = "ufodatacenter",
                    collection = "ufo_reports",
                    name = "uforeports",
                    description = "A collection of UFO text report documents. "
                };
            }
        }


        public override UfoDoc GetRandom()
        {
            var mongoclient = new MongoClient(UfoDB.Connection.settings);

            var server = mongoclient.GetServer();

            var db = server.GetDatabase(this.activeCollection.database);

            var collect = db.GetCollection(this.activeCollection.collection);

            Random rnd = new Random();          

            int skip = rnd.Next(0, (this.doc_count - 1));            

            UfoDoc document = new UfoDoc();

            document.textDoc = BsonSerializer.Deserialize<UfoTextDoc>(collect.AsQueryable().Skip(skip).First());

            return document;
        }

        
        protected override int GetCount()
        {
            var mongoclient = new MongoClient(UfoDB.Connection.settings);

            var server = mongoclient.GetServer();

            var db = server.GetDatabase(this.activeCollection.database);

            var collect = db.GetCollection(this.activeCollection.collection);

            var count = collect.FindAll().Count();

            return (int)count;
        }

    }
}
