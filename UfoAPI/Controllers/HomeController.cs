using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UfoDataCenter.info;
using MongoDB.Driver;
using MongoDB.Bson;

namespace UfoAPI.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public string Random()
        {
            UfoText vw = new UfoText("uforeports");            

            UfoDoc doc = vw.GetRandom();

            return doc.ToJson();            
        }

        [HttpGet]
        public string TextCollections()
        {
            UfoText t = new UfoText("uforeports");
            return t.reportCollections.ToJson();           
        }      
        
        [HttpGet]
        public string GetResults(string id)
        {
            UfoText vw = new UfoText("uforeports");
            UfoDoc doc = null;
            int results;
            switch (Int32.TryParse(id,out results))
            {
                case true:                    
                    doc = vw.GetSingle(results);
                    break;
                case false:
                    try
                    {
                        BsonObjectId _id = new BsonObjectId(new ObjectId(id));
                        doc = vw.GetSingle(_id);
                        break;
                    }
                    catch(Exception e)
                    {
                        return UfoError.UfoErrorResponse("Please supply an integer or valid BSON ID");
                    } 
            }
            return doc.ToJson();
        }

        [HttpPost]
        public string GetResultsP([FromBody] string collection, int page , int perpage = 0 )
        {
            UfoText vw;

            try
            {
                 vw = new UfoText(collection);
            }
            catch(Exception e)
            {
                return UfoError.UfoErrorResponse("Invalid collection name.");
            }
            
            if (perpage != 0)
                vw.perPage = perpage;

            UfoDoc doc = vw.GetPage(page);
            
            return doc.ToJson();
        }
    }
}
