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


        public UfoCollection activeCollection
        {
            get { return this._activeCollection; }

        }

        public abstract string ufoDocType { get; }
        private UfoCollection _activeCollection { get; set; }
        public abstract IEnumerable<UfoCollection> reportCollections
        {
            get;
        }

        public bool SetActive(string c_name)
        {
            var active = this.reportCollections.Where(x => x.name == c_name).SingleOrDefault();

            if (active != null)
            {
                this._activeCollection = active;
                return true;
            }
            else
                return false;
        }

        
        public int doc_count
        {
            get { return this.GetCount(); }
        }

    }
    
    public class UfoCollection
    {
        public string database { get; set; }
        public string collection { get; set; }
        public string description { get; set; }
        public string name { get; set; }

    }
}
