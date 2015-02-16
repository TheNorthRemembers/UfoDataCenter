using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UfoDataCenter.info;


namespace API.Controllers
{
    public class InfoController : ApiController
    {
        // GET info
        public IEnumerable<UfoCollection> Get()
        {           
            UfoText t = new UfoText("uforeports");
            return t.reportCollections;  
        }
    }
    
}