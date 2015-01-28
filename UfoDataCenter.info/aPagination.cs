using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UfoDataCenter.info
{
    

    public abstract partial class aUfo
    {
        public int perPage { get; set; }
        public abstract int pages { get; }
    }



    public class Pagination
    {
        public Pagination(int perPage,int pages)
        {
            this.perPage = perPage;
            this.pages = pages;
        }
        
        public int perPage { get; set; }
        public int pages { get; set; }

        public static int pageCount(int perPage,int count)
        { 
            return (count % perPage) == 0 ? count/perPage : (count/perPage) + 1;
        }

    }

}
