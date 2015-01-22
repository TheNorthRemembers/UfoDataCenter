using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UfoDB;


namespace UfoDataCenter.info
{
    public abstract class aUfoText
    {
        public abstract string GetTextRandom(UfoCollection setting);
        public abstract int GetCount(UfoCollection setting);
        public static UfoCollection ufo_reports
        {
            get
            {
                return new UfoCollection
                {
                    database = "ufodatacenter",
                    collection = "ufo_reports"
                };
            }
        }   
         
    }

    public class UfoCollection    {

        public string database { get; set; }
        public string collection { get; set; }

    }


}
