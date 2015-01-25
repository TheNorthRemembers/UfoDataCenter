using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
namespace UfoDataCenter.info
{
    public abstract partial class aUfo
    {
        public abstract UfoCollection activeCollection
        {
            get;
            
        }
        
        public abstract IEnumerable<UfoCollection> reports
        {
            get;
        }       
       
        public int doc_count
        {
            get { return this.GetCount(); } 
        }

    }
    public class UfoTextDoc
    {
        public BsonObjectId _id { get; set; }
        public string sighted_at { get; set; }
        public string reported_at { get; set; }
        public string location { get; set; }
        public string shape { get; set; }
        public string duration { get; set; }
        public string description { get; set; }

    }
    public class UfoCollection
    {
        public string database { get; set; }
        public string collection { get; set; }
        public string description { get; set; }

    }
}
