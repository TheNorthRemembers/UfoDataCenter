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
using UfoDataCenter.info.DataSources;
using MongoDB.Driver.Builders;

namespace UfoDataCenter.info
{
    public partial class UfoText : aUfo
    {
        public UfoText(string c_name) : base(c_name) { }

        public override string ufoDocType
        {
            get { return "text"; }
        }

        public override int pages
        {
            get
            {
                return (this.doc_count % this.perPage) == 0 ? this.doc_count / this.perPage : (this.doc_count / this.perPage) + 1;
            }
        }
        public override IEnumerable<UfoCollection> reportCollections
        {
            get
            {
                using (ufoSQLDataContext c = new ufoSQLDataContext())
                {
                    return c.ufo_collections.Where(x => x.type == this.ufoDocType).Select(y =>
                        new UfoCollection
                        {
                            collection = y.collection,
                            database = y.database,
                            description = y.description,
                            name = y.name
                        }).ToList();
                }
            }
        }


        public override UfoDoc GetSingle(int Nth)
        {   
            var collect = this.GetActiveDB();

            if (Nth > this.doc_count)
                Nth = this.doc_count;

            if (Nth < 1)
                Nth = 1;

            UfoDoc document = new UfoDoc();

            document.textDoc = new List<UfoTextDoc>() { BsonSerializer.Deserialize<UfoTextDoc>(collect.AsQueryable().Skip((Nth - 1)).First()) };

            document.pageInfo = new Pagination(this.perPage, this.pages);

            return document;
        }

        public override UfoDoc GetSingle(BsonObjectId id)
        {
            var collect = this.GetActiveDB();

            UfoDoc document = new UfoDoc();

            var query = Query.EQ("_id", id);

            document.textDoc = new List<UfoTextDoc>() { BsonSerializer.Deserialize<UfoTextDoc>(collect.Find(query).Single()) };

            document.pageInfo = new Pagination(this.perPage, this.pages);

            return document;
        }

        public override UfoDoc GetBySearch(UfoDoc criteria, int page)
        {

            var c = criteria.textDoc.FirstOrDefault();

            List<IMongoQuery> q = new List<IMongoQuery>();

            if (c._id != null)
                q.Add(Query.EQ("_id", c._id));
            if (c.description != null)
                q.Add(Query.Matches("description", new BsonRegularExpression(c.description)));
            if (c.duration != null)
                q.Add(Query.EQ("duration", c.duration));
            if (c.location != null)
                q.Add(Query.EQ("location", c.location));
            if (c.reported_at != null)
                q.Add(Query.EQ("reported_at", c.reported_at));
            if (c.shape != null)
                q.Add(Query.EQ("shape", c.shape));
            if (c.sighted_at != null)
                q.Add(Query.EQ("sighted_at", c.sighted_at));

            var collect = this.GetActiveDB();

            var query = Query.And(q);

            UfoDoc document = new UfoDoc();

            var results = collect.Find(query).ToList();

            List<UfoTextDoc> resultsList = new List<UfoTextDoc>();

            foreach (var result in results)
            {
                resultsList.Add(BsonSerializer.Deserialize<UfoTextDoc>(result));
            }

            document.textDoc = resultsList.Take(this.perPage);

            document.pageInfo = new Pagination(this.perPage, Pagination.pageCount(this.perPage, resultsList.Count));

            return document;
        }

        public override UfoDoc GetPage(int page)
        {
            throw new NotImplementedException();
        }


        public override UfoDoc GetRandom()
        {
            var collect = this.GetActiveDB();

            Random rnd = new Random();

            int skip = rnd.Next(0, (this.doc_count - 1));

            UfoDoc document = new UfoDoc();            

            document.textDoc = new List<UfoTextDoc>() { BsonSerializer.Deserialize<UfoTextDoc>(collect.AsQueryable().Skip(skip).First()) };

            document.pageInfo = new Pagination(this.perPage, this.pages);

            return document;
        }


        protected override int GetCount()
        {
            var collect = this.GetActiveDB();

            var count = collect.FindAll().Count();

            return (int)count;
        }

    }
}
