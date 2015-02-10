using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
namespace UfoDataCenter.info
{
    public class UfoDoc    {
        
        public IEnumerable<UfoTextDoc> textDoc { get; set; }
        public Pagination pageInfo { get; set; }
    }

    public class UfoTextDoc : UfoDocBase
    {
        public string sighted_at { get; set; }
        public string reported_at { get; set; }
        public string location { get; set; }
        public string shape { get; set; }
        public string duration { get; set; }
        public string description { get; set; }
    }

    public abstract class UfoDocBase
    {
        public BsonObjectId _id { get; set; }
    }


}
