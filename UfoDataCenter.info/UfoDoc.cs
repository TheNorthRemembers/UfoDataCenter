using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

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

        public string sightedPretty
        {
            get
            {
                string year = this.sighted_at.Substring(0, 4);
                string month = this.sighted_at.Substring(4, 2);
                string day = this.sighted_at.Substring(6);
                return month.Replace("0","") + '/' + day.Replace("0","") + '/' + year;
            }
        }

     }

    public class UfoDocBase
    {
        [BsonId]        
        public BsonObjectId _id
        {
            get;
            set;
        }

        
    }

    public class ShellTextDoc
    {
        public string id { get; set; }
        public string sighted_at { get; set; }
        public string reported_at { get; set; }
        public string location { get; set; }
        public string shape { get; set; }
        public string duration { get; set; }
        public string description { get; set; }
    }


}
