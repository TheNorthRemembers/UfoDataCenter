using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UfoDataCenter.info;
using MongoDB.Bson;

namespace API.Controllers
{
    public class InfoController : ApiController
    {
        // GET info
        public string Get()
        {
            UfoText t = new UfoText("uforeports");
            return t.reportCollections.ToJson();  
        }

      
    }
}