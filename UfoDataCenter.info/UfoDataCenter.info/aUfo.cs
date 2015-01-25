using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UfoDB;
using MongoDB.Bson;

namespace UfoDataCenter.info
{
    public abstract partial class aUfo
    {
        public abstract UfoTextDoc GetRandom();
        public abstract int GetCount();
       
         
    }

    


}
