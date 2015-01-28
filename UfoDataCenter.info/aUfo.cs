using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UfoDB;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoDB.Driver;
namespace UfoDataCenter.info
{
    public abstract partial class aUfo
    {   
        //constructor
        protected aUfo(string c_name)
        {
            this._activeCollection = this.reportCollections.Where(x => x.name == c_name).SingleOrDefault();
            this.perPage = 12;
        }
        
        public abstract UfoDoc GetRandom();
        protected abstract int GetCount();
        public abstract UfoDoc GetSingle(int Nth);
        public abstract UfoDoc GetSingle(BsonObjectId id);
        public abstract UfoDoc GetPage(int page);
        public abstract UfoDoc GetBySearch(UfoDoc criteria, int page);        
         
    }

    


}
