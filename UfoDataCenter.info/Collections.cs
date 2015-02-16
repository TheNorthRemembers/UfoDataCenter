using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UfoDataCenter.info
{
    public class UfoCollection
    {
        public string database { get; set; }
        public string collection { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string count
        {
            //read collections from db, then get count
            get
            {                
                    switch (this.type.ToUpper())
                    {
                        case "TEXT":
                            UfoText t = new UfoText(this.name);
                            return t.doc_count.ToString();
                        default:
                            return "";
                    }                   
               
            }          

        }

    }
}
