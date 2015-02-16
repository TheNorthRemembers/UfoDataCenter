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
    public class RandomController : ApiController
    {
        // GET /random
        public string Get()
        {
            UfoText vw = new UfoText("uforeports");

            return vw.GetRandom().ToJson();            
        }

       
    }
}