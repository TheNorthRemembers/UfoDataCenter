﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
namespace UfoDataCenter.info
{
    public abstract partial class aUfo
    {
        public UfoCollection activeCollection
        {
            get { return this._activeCollection; }
            
        }
        
        public abstract IEnumerable<UfoCollection> reports
        {
            get;
        }

        public bool SetActive(string c_name)
        {
            var active = this.reports.Where(x => x.name == c_name).SingleOrDefault();

            if (active != null)
                return true;
            else
                return false;
        }

        private UfoCollection _activeCollection { get; set; }
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

        public string name { get; set; }

    }
}