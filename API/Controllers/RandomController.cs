using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UfoDataCenter.info;
using Newtonsoft.Json;
namespace API.Controllers
{
    public class RandomController : ApiController
    {
        // GET /random
        //Ember Friendly
        public UfoDoc Get()
        {
            UfoText vw = new UfoText("uforeports");            
            var doc = vw.GetRandom();            
            return doc;  
        }

       
    }
}